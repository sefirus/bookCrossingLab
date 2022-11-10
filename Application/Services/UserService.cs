using Core.Entities;
using Core.Enums;
using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class UserService : IUserService
{
    private readonly IRepository<User> _userRepository;
    private readonly IRepository<Role> _roleRepository;
    private readonly IImageService _imageService;

    public UserService(
        IRepository<User> userRepository,
        IRepository<Role> roleRepository, 
        IImageService imageService)
    {
        _userRepository = userRepository;
        _roleRepository = roleRepository;
        _imageService = imageService;
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
        var regularUserRole = await _roleRepository
            .GetFirstOrThrowAsync(role => role.Name == ApplicationRoles.RegularUser);
        newUser.RoleId = regularUserRole.Id;
        newUser.Role = regularUserRole;
        
        await _userRepository.InsertAsync(newUser);
        await _userRepository.SaveChangesAsync();
    }
    
    public async Task<User> GetCurrentUserAsync(HttpContext context)
    {
        var claim = context.User.Claims.FirstOrDefault(claim => claim.Type.Contains("EmailAddress"));
        if (claim is null)
        {
            throw new BadRequestException("The user is not logged in");
        }
        var user = await _userRepository.GetFirstOrThrowAsync(
            filter: u => u.Email == claim.Value,
            include: query => query.Include(u => u.Role));
        return user;
    }

    public async Task<User> GetUserByIdAsync(int userId)
    {
        var wantedUser = await _userRepository.GetFirstOrThrowAsync(
            filter: user => user.Id == userId,
            include: query => query
                .Include(user => user.Comments)
                .Include(user => user.ProfilePicture)
                .Include(user => user.CurrentBooks)
                    .ThenInclude(bookCopy => bookCopy.Book)
                    .ThenInclude(book => book.Pictures));
        return wantedUser;
    }

    public async Task UpdateUserAsync(User newUser)
    {
        var oldUser = await _userRepository.GetFirstOrThrowAsync(
            filter: user => user.Id == newUser.Id,
            include: query => query
                .Include(user => user.ProfilePicture)
        );
        if (newUser.ProfilePicture?.FullPath != null 
            && newUser.ProfilePicture?.FullPath != oldUser.ProfilePicture?.FullPath)
        {
            var pictureList = _imageService.MapPictures(new[] { newUser.ProfilePicture?.FullPath });
            await _imageService.ClearUnusedImagesAsync(pictureList, newUser.Id, PictureOperationType.EditingUser);
            oldUser.ProfilePicture = pictureList.FirstOrDefault();
        }

        oldUser.Email = newUser.Email;
        oldUser.FirstName = newUser.FirstName;
        oldUser.LastName = newUser.LastName;
        oldUser.BirthDate = newUser.BirthDate;
        await _userRepository.SaveChangesAsync();
    }
}