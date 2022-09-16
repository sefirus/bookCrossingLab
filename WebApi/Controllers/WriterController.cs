using Application.Services;
using Core.Entities;
using Core.Interfaces.Mappers;
using Core.Interfaces.Services;
using Core.ViewModels.WriterViewModels;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/writers")]
[ApiController]
public class WriterController : ControllerBase
{
    private readonly IWriterService _writerService;
    private readonly IVmMapper<Writer, ReadWriterViewModel> _readMapper;
    private readonly IVmMapper<CreateWriterViewModel, Writer> _createMapper;
    private readonly IVmMapper<UpdateWriterViewModel, Writer> _updateMapper;

    public WriterController(
        IWriterService writerService, 
        IVmMapper<Writer, ReadWriterViewModel> readMapper, 
        IVmMapper<CreateWriterViewModel, Writer> createMapper, 
        IVmMapper<UpdateWriterViewModel, Writer> updateMapper)
    {
        _writerService = writerService;
        _readMapper = readMapper;
        _createMapper = createMapper;
        _updateMapper = updateMapper;
    }

    [HttpGet("{id:int:min(1)}")]
    public async Task<ReadWriterViewModel> GetWriterById([FromRoute]int id)
    {
        var writer = await _writerService.GetWriterByIdAsync(id);
        var viewModel = _readMapper.Map(writer);
        return viewModel;
    }

    [HttpPost]
    public async Task AddWriter([FromBody]CreateWriterViewModel viewModel)
    {
        var writer = _createMapper.Map(viewModel);
        await _writerService.AddWriterAsync(writer);
    }

    [HttpPut]
    public async Task UpdateWriter([FromBody]UpdateWriterViewModel viewModel)
    {
        var writer = _updateMapper.Map(viewModel);
        await _writerService.UpdateWriterAsync(writer);
    }

    [HttpDelete("{id:int:min(1)}")]
    public async Task DeleteWriter([FromRoute] int id)
    {
        await _writerService.DeleteWriterAsync(id);
    }
}