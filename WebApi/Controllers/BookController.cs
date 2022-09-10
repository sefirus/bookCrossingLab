using Core.Interfaces.Services;
using Core.ViewModels.BookViewModels;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/books")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;
    private readonly IBookApiService _bookApiService;

    public BookController(
        IBookService bookService, 
        IBookApiService bookApiService)
    {
        _bookService = bookService;
        _bookApiService = bookApiService;
    }

    [HttpGet]
    public async Task<IEnumerable<SearchBookViewModel>> SearchBookAsync([FromQuery] string request)
    {
        var searchResults = await _bookApiService.SearchBookAsync(request);
        return searchResults;
    }

    [HttpPost]
    public async Task PostBookAsync([FromBody] SearchBookViewModel model)
    {
        await _bookApiService.AddBookToLibraryAsync(model);
    }
}