using Core.Entities;
using Core.Interfaces.Mappers;
using Core.Interfaces.Services;
using Core.ViewModels.PublisherViewModels;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/publishers")]
[ApiController]
public class PublisherController : ControllerBase
{
    private readonly IPublisherService _publisherService;
    private readonly IVmMapper<Publisher, ReadPublisherViewModel> _readMapper;
    private readonly IVmMapper<CreatePublisherViewModel, Publisher> _createMapper;
    private readonly IVmMapper<UpdatePublisherViewModel, Publisher> _updateMapper;

    public PublisherController(
        IPublisherService publisherService, 
        IVmMapper<Publisher, ReadPublisherViewModel> readMapper, 
        IVmMapper<CreatePublisherViewModel, Publisher> createMapper, 
        IVmMapper<UpdatePublisherViewModel, Publisher> updateMapper)
    {
        _publisherService = publisherService;
        _readMapper = readMapper;
        _createMapper = createMapper;
        _updateMapper = updateMapper;
    }
    
    [HttpGet("{id:int:min(1)}")]
    public async Task<ReadPublisherViewModel> GetPublisherById([FromRoute]int id)
    {
        var publisher = await _publisherService.GetPublisherByIdAsync(id);
        var viewModel = _readMapper.Map(publisher);
        return viewModel;
    }

    [HttpPost]
    public async Task AddPublisher([FromBody]CreatePublisherViewModel viewModel)
    {
        var publisher = _createMapper.Map(viewModel);
        await _publisherService.AddPublisherAsync(publisher);
    }

    [HttpPut]
    public async Task UpdatePublisher([FromBody]UpdatePublisherViewModel viewModel)
    {
        var publisher = _updateMapper.Map(viewModel);
        await _publisherService.UpdatePublisherAsync(publisher);
    }

    [HttpDelete("{id:int:min(1)}")]
    public async Task DeletePublisher([FromRoute] int id)
    {
        await _publisherService.DeletePublisherAsync(id);
    }
}