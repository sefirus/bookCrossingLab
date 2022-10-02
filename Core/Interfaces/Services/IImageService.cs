using Core.Entities;
using Core.Enums;
using Microsoft.AspNetCore.Http;

namespace Core.Interfaces.Services;

public interface IImageService
{
    Task<string> UploadImageAsync(IFormFile file, int authorId, PictureOperationType operationType);
    Task DiscardCachedImagesAsync(int authorId, PictureOperationType pictureOperationType);
    Task ClearUnusedImagesAsync(IList<Picture> pictures, int authorId, PictureOperationType operationType);
    Task ClearUnusedImagesAsync(IList<string> imageLinks, int authorId, PictureOperationType operationType);
    Task DeleteImagesAsync(IList<Picture> pictures);
    Task DeleteImagesAsync(IEnumerable<string> imageLinks);
    Task ClearOutdatedImagesAsync(IList<Picture> oldPictures, IList<Picture> newPictures);
    Task ClearOutdatedImagesAsync(IList<string> oldPictureLinks, IList<string> newPictureLinks);
}