using Core.Entities;
using Core.Interfaces.Mappers;
using Core.Interfaces.Services;
using Core.Pagination.Parameters;
using Core.ViewModels;
using Core.ViewModels.CommentViewModels;
using Core.ViewModels.ShelfViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/shelves")]
[ApiController]
public class ShelfController : ControllerBase
{
    private readonly IShelfService _shelfService;
    private readonly IPagedVmMapper<Shelf, ReadShelfViewModel> _pagedMapper;
    private readonly IVmMapper<ShelfVmBase, Shelf> _createShelfMapper;
    private readonly IEnumerableVmMapper<Shelf, ReadShelfViewModel> _enumVmMapper;
    private readonly IVmMapper<CreateCommentViewModel, Comment> _createCommentMapper;
    private readonly IUserService _userService;
    private readonly ICommentService _commentService;
    private readonly IPagedVmMapper<Comment, ReadCommentViewModel> _commentMapper;

    public ShelfController(
        IShelfService shelfService,
        IPagedVmMapper<Shelf, ReadShelfViewModel> pagedMapper,
        IVmMapper<ShelfVmBase, Shelf> createShelfMapper,
        IEnumerableVmMapper<Shelf, ReadShelfViewModel> enumVmMapper, 
        IVmMapper<CreateCommentViewModel, Comment> createCommentMapper,
        IUserService userService,
        ICommentService commentService,
        IPagedVmMapper<Comment, ReadCommentViewModel> commentMapper)
    {
        _shelfService = shelfService;
        _pagedMapper = pagedMapper;
        _createShelfMapper = createShelfMapper;
        _enumVmMapper = enumVmMapper;
        _createCommentMapper = createCommentMapper;
        _userService = userService;
        _commentService = commentService;
        _commentMapper = commentMapper;
    }

    [HttpGet]
    public async Task<PagedViewModel<ReadShelfViewModel>> GetPagedShelves([FromQuery] ParametersBase parameters)
    {
        var shelves = await _shelfService.GetPagedShelvesAsync(parameters);
        var viewModel = _pagedMapper.Map(shelves);
        return viewModel;
    }

    [HttpPost("geo")]
    public async Task<IEnumerable<ReadShelfViewModel>> GetGeoShelves([FromBody] MapBoundaries boundaries)
    {
        var shelves = await _shelfService.GetShelvesInAreaAsync(boundaries);
        var viewModels = _enumVmMapper.Map(shelves);
        return viewModels;
    }

    [HttpPost]
    public async Task CreateShelf([FromBody] ShelfVmBase createVm)
    {
        var shelf = _createShelfMapper.Map(createVm);
        await _shelfService.AddShelfAsync(shelf);
    }

    [HttpDelete("{id:int:min(1)}")]
    public async Task DeleteShelf([FromRoute] int id)
    {
        await _shelfService.DeleteShelfByIdAsync(id);
    }

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
    public async Task<PagedViewModel<ReadCommentViewModel>> GetComments([FromRoute]int id, [FromQuery]ParametersBase parameters)
    {
        var comments = await _commentService.GetPagedCommentsAsync(
            parameters: parameters,
            additionalFilter: c => c.ShelfId == id);
        var vm = _commentMapper.Map(comments);
        return vm;
    }
}