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

[Route("api/bookcopies")]
[ApiController]
public class BookCopyController : ControllerBase
{
    private readonly IBookCopyService _bookCopyService;
    private readonly IUserService _userService;
    private readonly IPagedVmMapper<Comment, ReadCommentViewModel> _pagedCommentMapper;
    private readonly ICommentService _commentService;
    private readonly IVmMapper<CreateCommentViewModel, Comment> _createCommentMapper;

    public BookCopyController(
        IBookCopyService bookCopyService,
        IUserService userService, 
        ICommentService commentService, 
        IPagedVmMapper<Comment, ReadCommentViewModel> pagedCommentMapper, 
        IVmMapper<CreateCommentViewModel, Comment> createCommentMapper)
    {
        _bookCopyService = bookCopyService;
        _userService = userService;
        _commentService = commentService;
        _pagedCommentMapper = pagedCommentMapper;
        _createCommentMapper = createCommentMapper;
    }

    [Authorize]
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
    
    [Authorize]
    [HttpPost("{id:int:min(1)}/comments")]
    public async Task PostComment([FromRoute]int id, [FromBody]CreateCommentViewModel commentViewModel)
    {
        var newComment = _createCommentMapper.Map(commentViewModel);
        var user = await _userService.GetCurrentUserAsync(HttpContext);
        newComment.AuthorId = user.Id;
        await _bookCopyService.AddCommentOnBookCopyAsync(id, newComment);
    }
    
    [HttpGet("{id:int:min(1)}/comments")]
    public async Task<PagedViewModel<ReadCommentViewModel>> GetComments([FromRoute]int id, [FromQuery]ParametersBase parameters)
    {
        var comments = await _commentService.GetPagedCommentsAsync(
            parameters: parameters,
            additionalFilter: c => c.BookCopyId == id);
        var vm = _pagedCommentMapper.Map(comments);
        return vm;
    }
}