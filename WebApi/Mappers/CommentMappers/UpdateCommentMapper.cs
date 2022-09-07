using Core.Entities;
using Core.Interfaces.Mappers;
using Core.ViewModels.CommentViewModels;

namespace WebApi.Mappers.CommentMappers;

public class UpdateCommentMapper : IVmMapper<UpdateCommentViewModel, Comment>
{
    public Comment Map(UpdateCommentViewModel source)
    {
        var comment = new Comment()
        {
            Id = source.Id,
            Rate = source.Rate,
            Content = source.Content
        };
        return comment;
    }
}