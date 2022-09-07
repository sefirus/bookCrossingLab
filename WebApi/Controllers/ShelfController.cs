using System.Drawing;
using Core.Entities;
using Core.Interfaces.Mappers;
using Core.Interfaces.Services;
using Core.Pagination.Parameters;
using Core.ViewModels;
using Core.ViewModels.ShelfViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/shelves")]
[ApiController]
public class ShelfController : ControllerBase
{
    private readonly IShelfService _shelfService;
    private readonly IPagedVmMapper<Shelf, ReadShelfViewModel> _pagedMapper;
    private readonly IVmMapper<ShelfVmBase, Shelf> _createMapper;
    private readonly IEnumerableVmMapper<Shelf, ReadShelfViewModel> _enumVmMapper;

    public ShelfController(
        IShelfService shelfService,
        IPagedVmMapper<Shelf, ReadShelfViewModel> pagedMapper,
        IVmMapper<ShelfVmBase, Shelf> createMapper,
        IEnumerableVmMapper<Shelf, ReadShelfViewModel> enumVmMapper)
    {
        _shelfService = shelfService;
        _pagedMapper = pagedMapper;
        _createMapper = createMapper;
        _enumVmMapper = enumVmMapper;
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
        var shelf = _createMapper.Map(createVm);
        await _shelfService.AddShelfAsync(shelf);
    }

    [HttpDelete("{id:int:min(1)}")]
    public async Task DeleteShelf([FromRoute] int id)
    {
        await _shelfService.DeleteShelfByIdAsync(id);
    }

    [HttpGet("qr/{id:int:min(1)}")]
    public async Task<FileResult> GetQr([FromRoute] int id)
    {
        var file = await _shelfService.GetShelfQrCodeFileAsync(id);
        return File(file, "image/png");
    }
}