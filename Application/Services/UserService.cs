using System.Security.Cryptography;
using System.Text;
using Core.Entities;
using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;

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
        CreatePasswordHash(password, out var passwordHash, out var passwordSalt);
        newUser.PasswordHash = passwordHash;
        newUser.PasswordSalt = passwordSalt;

        await _userRepository.InsertAsync(newUser);
        await _userRepository.SaveChangesAsync();
    }

    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using var hmac = new HMACSHA512();
        passwordSalt = hmac.Key;
        passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
    }
}