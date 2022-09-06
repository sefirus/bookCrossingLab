using Core.Interfaces.Services;
using Core.ViewModels.BookViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/bookcopies")]
[ApiController]
public class BookCopyController : ControllerBase
{
    private readonly IBookCopyService _bookCopyService;
    private readonly IUserService _userService;

    public BookCopyController(
        IBookCopyService bookCopyService,
        IUserService userService)
    {
        _bookCopyService = bookCopyService;
        _userService = userService;
    }

    [HttpPost]
    public async Task CreateBookCopy([FromBody]SearchBookViewModel bookViewModel)
    {
        var currentUser = await _userService.GetCurrentUserAsync(HttpContext);
        await _bookCopyService.CreateBookCopyAsync(bookViewModel, currentUser);
    }

    [Authorize]
    [HttpPatch("reserve/{id:int:min(1)}")]
    public async Task ReserveBookCopy([FromRoute]int id)
    {
        var currentUser = await _userService.GetCurrentUserAsync(HttpContext);
        await _bookCopyService.ReserveAsync(id, currentUser);
    }

    [Authorize]
    [HttpPatch("return/{copyId:int:min(1)}")]
    public async Task PutOnShelf([FromRoute] int copyId, [FromQuery]int shelfId)
    {
        var currentUser = await _userService.GetCurrentUserAsync(HttpContext);
        await _bookCopyService.PutOnShelfAsync(copyId, currentUser, shelfId);
    }

    [Authorize]
    [HttpPatch("take/{id:int:min(1)}")]
    public async Task TakeFromShelf([FromRoute] int id)
    {
        var currentUser = await _userService.GetCurrentUserAsync(HttpContext);
        await _bookCopyService.TakeFromShelfAsync(id, currentUser);
    }
}