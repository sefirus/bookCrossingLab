using Core.ViewModels.PublisherViewModels;
using FluentValidation;

namespace WebApi.Validators.PublisherValidators;

public class UpdatePublisherValidator : AbstractValidator<UpdatePublisherViewModel>
{
    public UpdatePublisherValidator()
    {
        RuleFor(publisher => publisher.Id)
            .GreaterThan(1)
            .WithMessage("Invalid publisher id");    
        
        RuleFor(publisher => publisher.Name)
            .MaximumLength(250)
            .WithMessage("Maximum name length must be lower than 200")
            .MinimumLength(1)
            .WithMessage("Minimum name length must be greater than 1");
        
        RuleFor(publisher => publisher.Description)
            .MaximumLength(600)
            .WithMessage("Maximum description length must be lower than 1000")
            .MinimumLength(1)
            .WithMessage("Minimum description length must be greater than 1");
    }
}