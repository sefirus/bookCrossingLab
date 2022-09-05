using Application.Services;
using Core.Interfaces.Services;
using Core.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/login")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService; 
    
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    
    [HttpPost]
    public async Task<string> LoginAsync([FromBody] LoginViewModel loginViewModel)
    {
        var token = await _authService.Login(loginViewModel.Email, loginViewModel.Password);
        return token;
    }
    
}