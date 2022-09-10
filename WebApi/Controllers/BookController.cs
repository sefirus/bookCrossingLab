using Core.Entities;
using Core.Interfaces.Mappers;
using Core.Interfaces.Services;
using Core.Pagination.Parameters;
using Core.ViewModels;
using Core.ViewModels.BookViewModels;
using Core.ViewModels.CommentViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/books")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;
    private readonly IBookApiService _bookApiService;
    private readonly IVmMapper<CreateCommentViewModel, Comment> _createCommentMapper;
    private readonly IPagedVmMapper<Comment, ReadCommentViewModel> _pagedCommentMapper;
    private readonly ICommentService _commentService;
    private readonly IUserService _userService;

    public BookController(
        IBookService bookService, 
        IBookApiService bookApiService, 
        IVmMapper<CreateCommentViewModel, Comment> createCommentMapper,
        IPagedVmMapper<Comment, ReadCommentViewModel> pagedCommentMapper,
        ICommentService commentService, IUserService userService)
    {
        _bookService = bookService;
        _bookApiService = bookApiService;
        _createCommentMapper = createCommentMapper;
        _pagedCommentMapper = pagedCommentMapper;
        _commentService = commentService;
        _userService = userService;
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
    
    [Authorize]
    [HttpPost("{id:int:min(1)}/comments")]
    public async Task PostComment([FromRoute]int id, [FromBody]CreateCommentViewModel commentViewModel)
    {
        //var isBookFromGoogleApi = !int.TryParse(id, out int bookId);
        var newComment = _createCommentMapper.Map(commentViewModel);
        var user = await _userService.GetCurrentUserAsync(HttpContext);
        newComment.AuthorId = user.Id;
        await _bookService.AddCommentOnBookAsync(id, newComment);
    }
    
    [HttpGet("{id:int:min(1)}/comments")]
    public async Task<PagedViewModel<ReadCommentViewModel>> GetComments([FromRoute]int id, [FromQuery]ParametersBase parameters)
    {
        var comments = await _commentService.GetPagedCommentsAsync(
            parameters: parameters,
            additionalFilter: c => c.BookId == id);
        var vm = _pagedCommentMapper.Map(comments);
        return vm;
    }
}