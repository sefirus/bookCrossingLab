using Azure.Storage.Blobs;
using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Repositories;


public class ImageRepository : IImageRepository
{
    private readonly IConfiguration _configuration;
    private readonly BlobServiceClient _blobServiceClient;
    private readonly IRepository<Picture> _pictureRepository;

    public ImageRepository(
        IConfiguration configuration, 
        BlobServiceClient blobServiceClient, 
        IRepository<Picture> pictureRepository)
    {
        _configuration = configuration;
        _blobServiceClient = blobServiceClient;
        _pictureRepository = pictureRepository;
    }

    public async Task<string> UploadFromIFormFile(IFormFile file, string folder, string fileName = "")
    {
        var blobContainer = _blobServiceClient.GetBlobContainerClient(_configuration["Azure:ContainerName"]);
        if (string.IsNullOrEmpty(fileName))
        {
            fileName = Guid.NewGuid().ToString();
        }

        var imageFormat = file.ContentType.Split('/').Last();

        var fullFilePath = $"{folder}/{fileName}.{imageFormat}";
        var ms = new MemoryStream();
        var blobClient = blobContainer.GetBlobClient(fullFilePath);
        await file.CopyToAsync(ms);
        ms.Position = 0;

        await blobClient.UploadAsync(ms);

        return $"{_configuration["Azure:ContainerLink"]}/{_configuration["Azure:ContainerName"]}/{fullFilePath}";
    }

    public async Task DeleteFromBlobAsync(string fullPath)
    {
        var blobContainer = _blobServiceClient.GetBlobContainerClient(_configuration["Azure:ContainerName"]);
        var filePath = fullPath.Split(_configuration["Azure:ContainerName"]).Last();
        var blobClient = blobContainer.GetBlobClient(filePath);
        await blobClient.DeleteAsync();
    }

    public async Task DeleteFromBlobAndDbAsync(string fullPath)
    {
        await DeleteFromBlobAsync(fullPath);
        var pictureToDelete = await _pictureRepository
            .GetFirstOrDefaultAsync(picture => picture.FullPath == fullPath);
        if (pictureToDelete is not null)
        {
            _pictureRepository.Delete(pictureToDelete);
            await _pictureRepository.SaveChangesAsync();
        }
    }
}