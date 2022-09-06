using Core.Interfaces.Services;
using Core.ViewModels.BookViewModels;
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
}