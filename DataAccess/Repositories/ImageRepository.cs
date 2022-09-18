using Azure.Storage.Blobs;
using Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Repositories;


public class ImageRepository : IImageRepository
{
    private readonly IConfiguration _configuration;
    private readonly BlobServiceClient _blobServiceClient;

    public ImageRepository(
        IConfiguration configuration, 
        BlobServiceClient blobServiceClient)
    {
        _configuration = configuration;
        _blobServiceClient = blobServiceClient;
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

    public async Task DeleteAsync(string imageName, string folder)
    {
        var blobContainer = _blobServiceClient.GetBlobContainerClient(_configuration["Azure:ContainerName"]);
        var blobClient = blobContainer.GetBlobClient($"{folder}/{imageName}");
        await blobClient.DeleteAsync();
    }
}