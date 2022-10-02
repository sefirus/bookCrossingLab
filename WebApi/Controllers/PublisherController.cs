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
    private readonly IUserService _userService;
    private readonly IVmMapper<Publisher, ReadPublisherViewModel> _readMapper;
    private readonly IVmMapper<CreatePublisherViewModel, Publisher> _createMapper;
    private readonly IVmMapper<UpdatePublisherViewModel, Publisher> _updateMapper;

    public PublisherController(
        IPublisherService publisherService, 
        IVmMapper<Publisher, ReadPublisherViewModel> readMapper, 
        IVmMapper<CreatePublisherViewModel, Publisher> createMapper, 
        IVmMapper<UpdatePublisherViewModel, Publisher> updateMapper, 
        IUserService userService)
    {
        _publisherService = publisherService;
        _readMapper = readMapper;
        _createMapper = createMapper;
        _updateMapper = updateMapper;
        _userService = userService;
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
        var user = await _userService.GetCurrentUserAsync(HttpContext);
        await _publisherService.AddPublisherAsync(publisher, user.Id, viewModel.ImageLinks);
    }

    [HttpPut]
    public async Task UpdatePublisher([FromBody]UpdatePublisherViewModel viewModel)
    {
        var publisher = _updateMapper.Map(viewModel);
        var user = await _userService.GetCurrentUserAsync(HttpContext);
        await _publisherService.UpdatePublisherAsync(publisher, user.Id, viewModel.ImageLinks);
    }

    [HttpDelete("{id:int:min(1)}")]
    public async Task DeletePublisher([FromRoute] int id)
    {
        await _publisherService.DeletePublisherAsync(id);
    }
}