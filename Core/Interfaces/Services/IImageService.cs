using Core.Entities;
using Core.Enums;
using Microsoft.AspNetCore.Http;

namespace Core.Interfaces.Services;

public interface IImageService
{
    Task<string> UploadImageAsync(IFormFile file, int authorId, PictureOperationType operationType);
    Task DiscardCachedImagesAsync(int authorId, PictureOperationType pictureOperationType);
    Task ClearUnusedImagesAsync(List<Picture> pictures, int authorId, PictureOperationType operationType);
    Task ClearUnusedImagesAsync(List<string> imageLinks, int authorId, PictureOperationType operationType);
    Task DeleteImagesAsync(List<Picture> pictures);
    Task DeleteImagesAsync(IEnumerable<string> imageLinks);
}