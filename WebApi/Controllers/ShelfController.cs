using Core.Entities;
using Core.Interfaces.Mappers;
using Core.Interfaces.Services;
using Core.Pagination;
using Core.Pagination.Parameters;
using Core.ViewModels;
using Core.ViewModels.BookCopyViewModels;
using Core.ViewModels.CommentViewModels;
using Core.ViewModels.ShelfViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Mappers.ShelfMappers;

namespace WebApi.Controllers;

[Route("api/shelves")]
[ApiController]
public class ShelfController : ControllerBase
{
    private readonly IShelfService _shelfService;
    private readonly IPagedVmMapper<Shelf, ReadShelfViewModel> _pagedMapper;
    private readonly IVmMapper<CreateShelfViewModel, Shelf> _createShelfMapper;
    private readonly IEnumerableVmMapper<Shelf, ReadShelfViewModel> _enumVmMapper;
    private readonly IVmMapper<CreateCommentViewModel, Comment> _createCommentMapper;
    private readonly IUserService _userService;
    private readonly ICommentService _commentService;
    private readonly IPagedVmMapper<Comment, ReadCommentViewModel> _pagedCommentMapper;
    private readonly IVmMapper<Shelf, ReadShelfViewModel> _readShelfMapper;
    private readonly IPagedVmMapper<BookCopy, ReadBookCopyViewModel> _pagedBookCopyMapper;

    public ShelfController(
        IShelfService shelfService,
        IPagedVmMapper<Shelf, ReadShelfViewModel> pagedMapper,
        IVmMapper<CreateShelfViewModel, Shelf> createShelfMapper,
        IEnumerableVmMapper<Shelf, ReadShelfViewModel> enumVmMapper, 
        IVmMapper<CreateCommentViewModel, Comment> createCommentMapper,
        IUserService userService,
        ICommentService commentService,
        IPagedVmMapper<Comment, ReadCommentViewModel> pagedCommentMapper,
        IVmMapper<Shelf, ReadShelfViewModel> readShelfMapper,
        IPagedVmMapper<BookCopy, ReadBookCopyViewModel> pagedBookCopyMapper)
    {
        _shelfService = shelfService;
        _pagedMapper = pagedMapper;
        _createShelfMapper = createShelfMapper;
        _enumVmMapper = enumVmMapper;
        _createCommentMapper = createCommentMapper;
        _userService = userService;
        _commentService = commentService;
        _pagedCommentMapper = pagedCommentMapper;
        _readShelfMapper = readShelfMapper;
        _pagedBookCopyMapper = pagedBookCopyMapper;
    }

    [HttpGet]
    public async Task<PagedViewModel<ReadShelfViewModel>> GetPagedShelves([FromQuery]FilteredParameters parameters)
    {
        var shelves = await _shelfService.GetPagedShelvesAsync(parameters);
        var viewModel = _pagedMapper.Map(shelves);
        return viewModel;
    }

    [HttpGet("{id:int:min(1)}")]
    public async Task<ReadShelfViewModel> GetShelfById([FromRoute] int id)
    {
        var shelf = await _shelfService.GetShelfByIdAsync(id);
        var shelfComments = shelf.Comments.ToList();
        var pagedComments = shelfComments.ToPagedList();
        var shelfBookCopies = shelf.BookCopies.ToList();
        var pagedBookCopies = shelfBookCopies.ToPagedList();
        var vm = _readShelfMapper.Map(shelf);
        vm.PagedComments = _pagedCommentMapper.Map(pagedComments);
        vm.PagedBookCopies = _pagedBookCopyMapper.Map(pagedBookCopies);
        return vm;
    }

    [HttpPost("geo")]
    public async Task<IEnumerable<ReadShelfViewModel>> GetGeoShelves([FromBody] MapBoundaries boundaries)
    {
        var shelves = await _shelfService.GetShelvesInAreaAsync(boundaries);
        var viewModels = _enumVmMapper.Map(shelves);
        return viewModels;
    }

    [Authorize(Roles = "SUPER ADMIN,POWER USER")]
    [HttpPost]
    public async Task CreateShelf([FromBody] CreateShelfViewModel createVm)
    {
        var shelf = _createShelfMapper.Map(createVm);
        await _shelfService.AddShelfAsync(shelf);
    }

    [Authorize(Roles = "SUPER ADMIN,POWER USER")]
    [HttpDelete("{id:int:min(1)}")]
    public async Task DeleteShelf([FromRoute] int id)
    {
        await _shelfService.DeleteShelfByIdAsync(id);
    }

    [Authorize(Roles = "SUPER ADMIN,POWER USER")]
    [HttpGet("{id:int:min(1)}/qr")]
    public async Task<FileResult> GetQr([FromRoute] int id)
    {
        var file = await _shelfService.GetShelfQrCodeFileAsync(id);
        return File(file, "image/png");
    }

    [Authorize]
    [HttpPost("{id:int:min(1)}/comments")]
    public async Task Comment([FromRoute]int id, [FromBody]CreateCommentViewModel viewModel)
    {
        var newComment = _createCommentMapper.Map(viewModel);
        var user = await _userService.GetCurrentUserAsync(HttpContext);
        newComment.AuthorId = user.Id;
        await _shelfService.AddCommentOnShelfAsync(id, newComment);
    }

    [HttpGet("{id:int:min(1)}/comments")]
    public async Task<PagedViewModel<ReadCommentViewModel>> GetComments([FromRoute]int id, [FromQuery]FilteredParameters parameters)
    {
        var comments = await _commentService.GetPagedCommentsAsync(
            parameters: parameters,
            additionalFilter: c => c.ShelfId == id);
        var vm = _pagedCommentMapper.Map(comments);
        return vm;
    }
}