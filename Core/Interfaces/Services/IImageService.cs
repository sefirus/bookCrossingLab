using Core.Enums;
using Microsoft.AspNetCore.Http;

namespace Core.Interfaces.Services;

public interface IImageService
{
    Task<string> UploadImageAsync(IFormFile file, int authorId, PictureOperationType operationType);
    Task DiscardCachedImagesAsync(int authorId, PictureOperationType pictureOperationType);

}