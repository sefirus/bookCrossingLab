using Core.ViewModels.UserViewModels;
using FluentValidation;

namespace WebApi.Validators.UserValidators;

public class UserValidatorBase<T> : AbstractValidator<T> where T : UserVmBase
{
    public UserValidatorBase()
    {
        RuleFor(user => user.Email)
            .MaximumLength(150)
            .WithMessage("Maximum email length must be lower than 150")
            .MinimumLength(1)
            .WithMessage("Minimum email length must be greater than 1");
        
        RuleFor(user => user.FirstName)
            .MaximumLength(150)
            .WithMessage("Maximum firstName length must be lower than 150")
            .MinimumLength(1)
            .WithMessage("Minimum firstName length must be greater than 1");
        
        RuleFor(user => user.LastName)
            .MaximumLength(150)
            .WithMessage("Maximum lastName length must be lower than 150")
            .MinimumLength(1)
            .WithMessage("Minimum lastName length must be greater than 1");
    }
}