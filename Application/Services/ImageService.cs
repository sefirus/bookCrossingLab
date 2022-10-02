using Azure;
using Core.Entities;
using Core.Enums;
using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

namespace Application.Services;

public class ImageService : IImageService
{
    private readonly IConfiguration _configuration;
    private readonly IImageRepository _imageRepository;
    private readonly IMemoryCache _memoryCache;
    private readonly ILoggerManager _loggerManager;

    public ImageService(
        IConfiguration configuration,
        IImageRepository imageRepository, 
        IMemoryCache memoryCache, 
        ILoggerManager loggerManager)
    {
        _configuration = configuration;
        _imageRepository = imageRepository;
        _memoryCache = memoryCache;
        _loggerManager = loggerManager;
    }

    public async Task ClearOutdatedImagesAsync(List<Picture> oldPictures, List<Picture> newPictures)
    {
        var oldPicturesLinks = oldPictures.Select(p => p.FullPath).ToList();
        var newPicturesLinks = newPictures.Select(p => p.FullPath).ToList();
        await ClearOutdatedImagesAsync(oldPicturesLinks, newPicturesLinks);
    }
    
    public async Task ClearOutdatedImagesAsync(List<string> oldPictureLinks, List<string> newPictureLinks)
    {
        // if (oldBody == newBody)
        // {
        //     return;
        // }
        foreach (var oldPicture in oldPictureLinks)
        {
            if (!newPictureLinks.Contains(oldPicture))
            {
                try
                {
                    await _imageRepository.DeleteAsync(oldPicture);
                }
                catch (RequestFailedException)
                {
                    _loggerManager.LogWarn("Error while deleting file from the blob");
                    throw new BadRequestException("Error while deleting file from the blob");
                }
                
            }
        }
    }

    public async Task DeleteImagesAsync(List<Picture> pictures)
    {
        await DeleteImagesAsync(pictures.Select(p => p.FullPath));
    }

    public async Task DeleteImagesAsync(IEnumerable<string> imageLinks)
    {
        foreach (var imageLink in imageLinks)
        {
            try
            {
                await _imageRepository.DeleteAsync(imageLink);
            }
            catch (RequestFailedException)
            {
                _loggerManager.LogWarn("Error while deleting file from the blob");
                throw new BadRequestException("Error while deleting file from the blob");
            }
        }
    }

    public async Task DiscardCachedImagesAsync(int authorId, PictureOperationType operationType)
    {
        var cacheKey = (authorId, pictureOperationType: operationType);
        var cachedList = _memoryCache.Get<List<string>>(cacheKey);
        if (cachedList is null || cachedList.Count == 0)
        {
            return;
        }

        foreach (var fullPath in cachedList)
        {
            try
            {
                await _imageRepository.DeleteAsync(fullPath);
            }
            catch (RequestFailedException)
            {
                _loggerManager.LogWarn("Error while deleting file from the blob");
                throw new BadRequestException("Error while deleting file from the blob");
            }
        }
        _memoryCache.Remove(authorId);
    }


    public async Task ClearUnusedImagesAsync(List<Picture> pictures, int authorId, PictureOperationType operationType)
    {
        var imageLinks = pictures.Select(p => p.FullPath).ToList();
        await ClearUnusedImagesAsync(imageLinks, authorId, operationType);
    }
    
    public async Task ClearUnusedImagesAsync(List<string> imageLinks, int authorId, PictureOperationType operationType)
    {
        var cacheKey = (authorId, pictureOperationType: operationType);
        var cachedList = _memoryCache.Get<List<string>>(cacheKey);
        if (cachedList is null || cachedList.Count == 0)
        {
            return;
        }

        foreach (var imageLink in cachedList)
        {
            if (!imageLinks.Contains(imageLink))
            {
                try
                {
                    await _imageRepository.DeleteAsync(imageLink);
                }
                catch (RequestFailedException)
                {
                    _loggerManager.LogWarn("Error while deleting file from the blob");
                    throw new BadRequestException("Error while deleting file from the blob");
                }
            }
        }
        _memoryCache.Remove(authorId);
    }

    private void EnsureFileFormat(IFormFile file)
    {
        var imageFormat = file.ContentType.Split('/').Last();
        var formats = _configuration
            .GetSection("AcceptableImageFormats")
            .GetSection("Formats")
            .AsEnumerable();
        
        if (!formats.Any(f => f.Value == imageFormat))
        { 
            throw new BadRequestException("Wrong image format!");
        }
    }

    public async Task<string> UploadImageAsync(IFormFile file, int authorId, PictureOperationType operationType)
    {
        EnsureFileFormat(file);
        string link;
        try
        {
             link = await _imageRepository.UploadFromIFormFile(file, operationType.GetFolderName());
        }
        catch (RequestFailedException)
        {
            _loggerManager.LogWarn("Error while uploading file to the blob");
            throw new BadRequestException("Error while uploading file to the blob");
        }
        var cacheKey = (authorId, pictureOperationType: operationType);
        var currentList = _memoryCache.Get<List<string>>(cacheKey) ?? new List<string>(); 
        currentList.Add(link);
        _memoryCache.Set(cacheKey, currentList,TimeSpan.FromMinutes(10));
        return link;
    }
}