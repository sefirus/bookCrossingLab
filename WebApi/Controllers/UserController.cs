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

    public UserController(
        IUserService userService, 
        IVmMapper<User, ReadUserViewModel> readMapper)
    {
        _userService = userService;
        _readMapper = readMapper;
    }

    [HttpGet("{id:int:min(1)}")]
    public async Task<ReadUserViewModel> GetUserByIdAsync([FromRoute] int id)
    {
        var user = await _userService.GetUserByIdAsync(id);
        var viewModel = _readMapper.Map(user);
        return viewModel;
    }
}