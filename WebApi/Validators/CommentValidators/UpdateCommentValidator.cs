using Core.ViewModels.CommentViewModels;
using FluentValidation;

namespace WebApi.Validators.CommentValidators;

public class UpdateCommentValidator : CommentValidatorBase<UpdateCommentViewModel>
{
    public UpdateCommentValidator()
    {
        RuleFor(c => c.Id)
            .GreaterThanOrEqualTo(1)
            .WithMessage("Invalid comment id");
    }
}