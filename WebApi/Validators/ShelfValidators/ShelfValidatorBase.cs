using Core.ViewModels.ShelfViewModels;
using FluentValidation;

namespace WebApi.Validators.ShelfValidators;

public class ShelfValidatorBase<T> : AbstractValidator<T> where T : ShelfVmBase
{
    public ShelfValidatorBase()
    {
        RuleFor(shelf => shelf.Latitude)
            .GreaterThanOrEqualTo(-90)
            .WithMessage("Latitude must be greater than -90 deg.")
            .LessThanOrEqualTo(90)
            .WithMessage("Latitude must be less than +90 deg.");
        
        RuleFor(shelf => shelf.Longitude)
            .GreaterThanOrEqualTo(-180)
            .WithMessage("Longitude must be greater than -180 deg.")
            .LessThanOrEqualTo(180)
            .WithMessage("Longitude must be less than 180 deg.");
        
        RuleFor(shelf => shelf.Title)
            .MaximumLength(250)
            .WithMessage("Maximum title length must be lower than 250")
            .MinimumLength(1)
            .WithMessage("Minimum title length must be greater than 1");
        
        RuleFor(shelf => shelf.FormattedAddress)
            .MaximumLength(250)
            .WithMessage("Maximum formattedAddress length must be lower than 250")
            .MinimumLength(1)
            .WithMessage("Minimum formattedAddress length must be greater than 1");
    }
}