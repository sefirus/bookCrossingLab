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
        HashHelper.CreatePasswordHash(password, out var passwordHash, out var passwordSalt);
        newUser.PasswordHash = passwordHash;
        newUser.PasswordSalt = passwordSalt;

        await _userRepository.InsertAsync(newUser);
        await _userRepository.SaveChangesAsync();
    }
}