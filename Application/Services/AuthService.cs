using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Core.Entities;
using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
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
            .GetFirstOrDefaultAsync(
                filter: user => user.Email == email,
                include: users => users.Include(u => u.Role));
        if (foundUser is null)
        {
            throw new BadRequestException();
        }

        if (!VerifyUser(password, foundUser.PasswordHash, foundUser.PasswordSalt))
        {
            throw new BadRequestException();
        }
        
        var token = CreateToken(foundUser);
        return token;
    }
    
    private bool VerifyUser(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using var hmac = new HMACSHA512(passwordSalt);
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        var equality = computedHash.SequenceEqual(passwordHash);
        return equality;
    }
    
    public string CreateToken(User user)
    {
        var expirationClaimValue = DateTime.Now
            .AddSeconds(int.Parse(_configuration.GetSection("Authorization:TokenLifeSpan").Value))
            .ToString(CultureInfo.CurrentCulture);
        var claims = new List<Claim>
        {
            new("EmailAddress", user.Email),
            new("Role", user.Role.Name),
            new("Expiration", expirationClaimValue),
            new("Id", user.Id.ToString())
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
}