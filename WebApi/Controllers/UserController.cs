using Core.Entities;
using Core.Interfaces.Mappers;
using Core.Interfaces.Services;
using Core.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IVmMapper<User, ReadUserViewModel> _readMapper;
    private readonly IVmMapper<UpdateUserViewModel, User> _updateMapper;

    public UserController(
        IUserService userService, 
        IVmMapper<User, ReadUserViewModel> readMapper, 
        IVmMapper<UpdateUserViewModel, User> updateMapper)
    {
        _userService = userService;
        _readMapper = readMapper;
        _updateMapper = updateMapper;
    }

    [HttpGet("{id:int:min(1)}")]
    public async Task<ReadUserViewModel> GetUserByIdAsync([FromRoute] int id)
    {
        var user = await _userService.GetUserByIdAsync(id);
        var viewModel = _readMapper.Map(user);
        return viewModel;
    }

    [HttpPut]
    public async Task UpdateUserAsync([FromBody] UpdateUserViewModel viewModel)
    {
        var newUser = _updateMapper.Map(viewModel);
        await _userService.UpdateUserAsync(newUser);
    }
}