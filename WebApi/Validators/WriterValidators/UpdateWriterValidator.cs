using Core.ViewModels.WriterViewModels;
using FluentValidation;

namespace WebApi.Validators.WriterValidators;

public class UpdateWriterValidator : AbstractValidator<UpdateWriterViewModel>
{
    public UpdateWriterValidator()
    {
        RuleFor(writer => writer.Id)
            .GreaterThan(1)
            .WithMessage("Invalid writer id");
        
        RuleFor(writer => writer.FullName)
            .MaximumLength(200)
            .WithMessage("Maximum fullName length must be lower than 200")
            .MinimumLength(1)
            .WithMessage("Minimum fullName length must be greater than 1");
        
        RuleFor(writer => writer.Description)
            .MaximumLength(1000)
            .WithMessage("Maximum description length must be lower than 1000")
            .MinimumLength(1)
            .WithMessage("Minimum description length must be greater than 1");
    }
}