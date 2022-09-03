using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.ViewModels.UserViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services;

public class AuthService : IAuthService
{
    private readonly IRepository<User> _userRepository;
    private readonly IConfiguration _configuration;

    public AuthService(
        IRepository<User> userRepository, IConfiguration configuration)
    {
        _userRepository = userRepository;
        _configuration = configuration;
    }
    
    public async Task<string> Login(string email, string password)
    {
        var foundUser = await _userRepository
            .GetFirstOrDefaultAsync(user => user.Email == email);
        if (foundUser is null)
        {
            throw new Exception(); //TODO: Create custom exception 
        }

        if (!VerifyUser(password, foundUser.PasswordHash, foundUser.PasswordSalt))
        {
            //TODO: Create and throw custom exception 
        }
        
        var token =  CreateToken(foundUser);
        return token;
    }
    
    private bool VerifyUser(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using var hmac = new HMACSHA512(passwordSalt);
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        return computedHash.SequenceEqual(passwordHash);
    }
    
    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using var hmac = new HMACSHA512();
        passwordSalt = hmac.Key;
        passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
    }

    private string CreateToken(User user)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.Email, user.Email),
            new(ClaimTypes.Role, "User"),
            new(ClaimTypes.Expiration, DateTime.Now.AddSeconds(15).ToString(CultureInfo.CurrentCulture))
        };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            _configuration.GetSection("Authorization:Token").Value));
        var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(15),
            signingCredentials: cred);

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);
        return jwt;
    }

    public async Task<string> NewUser(User newUser, string password)
    {
        var possiblyExisting = await _userRepository
            .GetFirstOrDefaultAsync(u => u.Email == newUser.Email);
        if (possiblyExisting is not null)
        {
            //TODO: Create and throw custom exception 
            throw new Exception();
        }
        CreatePasswordHash(password, out var passwordHash, out var passwordSalt);
        newUser.PasswordHash = passwordHash;
        newUser.PasswordSalt = passwordSalt;

        await _userRepository.InsertAsync(newUser);
        await _userRepository.SaveChangesAsync();
        
        var token = CreateToken(newUser);
        return token;
    }
}