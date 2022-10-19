using Core.Entities;
using Core.Interfaces.Mappers;
using Core.ViewModels.UserViewModels;

namespace WebApi.Mappers.UserMappers;

public class CreateUserMapper : IVmMapper<CreateUserViewModel, User>
{
    public User Map(CreateUserViewModel source)
    {
        var newUser = new User()
        {
            Email = source.Email,
            FirstName = source.FirstName,
            LastName = source.LastName,
            BirthDate = source.BirthDate
        };
        return newUser;
    }
}