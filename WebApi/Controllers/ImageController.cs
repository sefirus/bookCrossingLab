using Core.Enums;
using Core.Interfaces.Services;
using Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/images")]
[ApiController]
public class ImageController : ControllerBase
{
    private readonly IImageService _imageService;
    private readonly IUserService _userService;

    public ImageController(
        IImageService imageService, 
        IUserService userService)
    {
        _imageService = imageService;
        _userService = userService;
    }

    [Authorize]
    [HttpPost("{editingEntity}")]
    public async Task<ImageLinkVm> UploadImage(IFormFile file, [FromRoute]string editingEntity)
    {
        var author = await _userService.GetCurrentUserAsync(HttpContext);
        var operationType = editingEntity.GetPictureOperationType();
        var link = await _imageService.UploadImageAsync(file, author.Id, operationType);
        return new ImageLinkVm()
        {
            ImageUrl = link
        };
    }

    [Authorize]
    [HttpDelete("{editingEntity}")]
    public async Task DiscardEditing([FromRoute] string editingEntity)
    {
        var author = await _userService.GetCurrentUserAsync(HttpContext);
        var operationType = editingEntity.GetPictureOperationType();
        await _imageService.DiscardCachedImagesAsync(author.Id, operationType);
    }
}