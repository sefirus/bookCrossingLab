using Azure;
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
    
    public async Task ClearOutdatedImagesAsync(string newBody, string oldBody)
    {
        // if (oldBody == newBody)
        // {
        //     return;
        // }
        // var tagSplitter = new TagSplitter(oldBody);
        // while (tagSplitter.TryGetNextTag(out var tag))
        // {
        //     ParseImgTag(tag, out _, out var possibleFileName, out _);
        //     var fileName = possibleFileName.ToString();
        //     if (!string.IsNullOrEmpty(fileName) && !newBody.Contains(fileName))
        //     {
        //         try
        //         {
        //             await _imageRepository.DeleteAsync(possibleFileName.ToString(), "articles");
        //         }
        //         catch (RequestFailedException)
        //         {
        //             _loggerManager.LogWarn("Error while deleting file from the blob");
        //             throw new BadRequestException("Error while deleting file from the blob");
        //         }
        //     }
        // }
    }
    
    // public async Task<string> DeleteImagesAsync(string body)
    // {
    //     var tagSplitter = new TagSplitter(body);
    //     while (tagSplitter.TryGetNextTag(out var tag, out var startIndex, out var length))
    //     {
    //         ParseImgTag(tag, out var link, out var fileName, out var isOuterLink);
    //     
    //         if (!isOuterLink)
    //         {
    //             try
    //             {
    //                 await _imageRepository.DeleteAsync(fileName.ToString(), folder: "articles");
    //             }
    //             catch (RequestFailedException)
    //             {
    //                 _loggerManager.LogWarn("Error while deleting file from the blob");
    //                 throw new BadRequestException("Error while deleting file from the blob");
    //             }
    //         }
    //     
    //         body = body.Remove(
    //             startIndex: startIndex,
    //             count: length);
    //         tagSplitter.RemoveTag(body);
    //     }
    //     
    //      return body;
    // }

    public async Task DiscardCachedImagesAsync(int authorId)
    {
        var cachedList = _memoryCache.Get<List<string>>(authorId);
        if (cachedList is null || cachedList.Count == 0)
        {
            return;
        }

        foreach (var fileName in cachedList)
        {
            try
            {
                await _imageRepository.DeleteAsync(fileName, "articles");
            }
            catch (RequestFailedException)
            {
                _loggerManager.LogWarn("Error while deleting file from the blob");
                throw new BadRequestException("Error while deleting file from the blob");
            }
        }
        _memoryCache.Remove(authorId);
    }

    public async Task ClearUnusedImagesAsync(string body, int authorId)
    {
        var cachedList = _memoryCache.Get<List<string>>(authorId);
        if (cachedList is null || cachedList.Count == 0)
        {
            return;
        }

        foreach (var fileName in cachedList)
        {
            if (!body.Contains(fileName))
            {
                try
                {
                    await _imageRepository.DeleteAsync(fileName, "articles");
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

    public async Task<string> UploadImageAsync(IFormFile file, int authorId)
    {
        EnsureFileFormat(file);
        string link;
        try
        {
             link = await _imageRepository.UploadFromIFormFile(file, "articles");
        }
        catch (RequestFailedException)
        {
            _loggerManager.LogWarn("Error while uploading file to the blob");
            throw new BadRequestException("Error while uploading file to the blob");
        }
        var fileName = link.Split('/').Last();
        var currentList = _memoryCache.Get<List<string>>(authorId) ?? new List<string>(); 
        currentList.Add(fileName);
        _memoryCache.Set(authorId, currentList,TimeSpan.FromMinutes(10));
        return link;
    }
}