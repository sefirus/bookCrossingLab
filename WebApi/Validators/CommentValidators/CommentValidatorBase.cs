using Core.ViewModels.CommentViewModels;
using FluentValidation;

namespace WebApi.Validators.CommentValidators;

public class CommentValidatorBase<T> : AbstractValidator<T> where T : CommentVmBase
{
    public CommentValidatorBase()
    {
        RuleFor(c => c.Content)
            .MaximumLength(400)
            .WithMessage("Maximum content length must be lower than 400")
            .MinimumLength(1)
            .WithMessage("Minimum content length must be greater than 1");

        RuleFor(c => c.Rate)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Rate must be greater than or equal to 0")
            .LessThanOrEqualTo(5)
            .WithMessage("Rate mus ne lower than or equal to 5");

    }
}