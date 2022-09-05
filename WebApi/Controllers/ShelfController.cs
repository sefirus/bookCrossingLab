using Application.Services;
using Core.Entities;
using Core.Interfaces.Mappers;
using Core.Interfaces.Services;
using Core.Pagination;
using Core.Pagination.Parameters;
using Core.ViewModels;
using Core.ViewModels.ShelfViewModels;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/shelves")]
[ApiController]
public class ShelfController : ControllerBase
{
    private readonly IShelfService _shelfService;
    private readonly IPagedVmMapper<Shelf, ReadShelfViewModel> _pagedMapper;

    public ShelfController(
        IShelfService shelfService,
        IPagedVmMapper<Shelf, ReadShelfViewModel> pagedMapper)
    {
        _shelfService = shelfService;
        _pagedMapper = pagedMapper;
    }

    [HttpGet]
    public async Task<PagedViewModel<ReadShelfViewModel>> GetPagedAsync([FromQuery] ParametersBase parameters)
    {
        var shelves = await _shelfService.GetPagedShelvesAsync(parameters);
        var vm = _pagedMapper.Map(shelves);
        return vm;
    }
}