using Core.Entities;
using Core.Enums;
using Microsoft.AspNetCore.Http;

namespace Core.Interfaces.Services;

public interface IImageService
{
    Task<string> UploadImageAsync(IFormFile file, int authorId, PictureOperationType operationType);
    Task DiscardCachedImagesAsync(int authorId, PictureOperationType pictureOperationType);
    Task ClearUnusedImagesAsync(IList<Picture> pictures, int authorId, PictureOperationType operationType);
    Task DeleteImagesAsync(IList<Picture> pictures);
    Task ClearOutdatedImagesAsync(IList<Picture> oldPictures, IList<Picture> newPictures);
    IList<Picture> MapPictures(IEnumerable<string> imageLinks, List<Picture>? existing = null);
}