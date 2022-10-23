using Core.Entities;
using Core.Interfaces.Mappers;
using Core.ViewModels.UserViewModels;

namespace WebApi.Mappers.UserMappers;

public class UpdateUserMapper : IVmMapper<UpdateUserViewModel, User>
{
    public User Map(UpdateUserViewModel source)
    {
        var user = new User()
        {
            Id = source.Id,
            Email = source.Email,
            FirstName = source.FirstName,
            LastName = source.LastName,
            BirthDate = source.BirthDate,
            ProfilePicture = new Picture()
            {
                FullPath = source.ProfilePicture
            }
        };
        return user;
    }
}