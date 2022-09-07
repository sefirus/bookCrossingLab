using Core.Entities;
using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class UserService : IUserService
{
    private readonly IRepository<User> _userRepository;

    public UserService(IRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task CreateUser(User newUser, string password)
    {
        var possiblyExisting = await _userRepository
            .GetFirstOrDefaultAsync(u => u.Email == newUser.Email);
        if (possiblyExisting is not null)
        {
            throw new BadRequestException();
        }
        HashHelper.CreatePasswordHash(password, out var passwordHash, out var passwordSalt);
        newUser.PasswordHash = passwordHash;
        newUser.PasswordSalt = passwordSalt;

        await _userRepository.InsertAsync(newUser);
        await _userRepository.SaveChangesAsync();
    }
    
    public async Task<User> GetCurrentUserAsync(HttpContext context)
    {
        var claim = context.User.Claims.FirstOrDefault(claim => claim.Type.Contains("emailaddress"));
        if (claim is null)
        {
            throw new BadRequestException("The user is not logged in");
        }
        var user = await _userRepository.GetFirstOrThrowAsync(
            filter: u => u.Email == claim.Value,
            include: query => query.Include(u => u.Role));
        return user;
    }
}