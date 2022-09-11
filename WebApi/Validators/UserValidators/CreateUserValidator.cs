using Core.ViewModels.UserViewModels;
using FluentValidation;

namespace WebApi.Validators.UserValidators;

public class CreateUserValidator : UserValidatorBase<CreateUserViewModel>
{
    public CreateUserValidator()
    {
        RuleFor(user => user.Password)
            .MaximumLength(50)
            .WithMessage("Maximum password length must be lower than 50")
            .MinimumLength(1)
            .WithMessage("Minimum password length must be greater than 1");
    }    
}