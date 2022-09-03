using Core.Entities;

namespace Core.Interfaces.Services;

public interface IUserService
{
    Task CreateUser(User newUser, string password);
}