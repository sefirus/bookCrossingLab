using Core.Entities;
using Microsoft.AspNetCore.Http;

namespace Core.Interfaces.Services;

public interface IUserService
{
    Task CreateUser(User newUser, string password);
    Task<User> GetCurrentUserAsync(HttpContext context);
    Task<User> GetUserByIdAsync(int userId);
    Task UpdateUserAsync(User newUser);
}