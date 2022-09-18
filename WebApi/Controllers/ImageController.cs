using Core.Interfaces.Services;
using Core.ViewModels;
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

    [HttpPost]
    public async Task<ImageLinkVm> UploadImage(IFormFile file)
    {
        //var author = _userService.GetCurrentUserAsync(HttpContext);
        var link = await _imageService.UploadImageAsync(file, 123);
        return new ImageLinkVm()
        {
            ImageUrl = link
        };
    }
}