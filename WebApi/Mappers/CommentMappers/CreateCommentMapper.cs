using Core.Entities;
using Core.Interfaces.Mappers;
using Core.ViewModels.CommentViewModels;

namespace WebApi.Mappers.CommentMappers;

public class CreateCommentMapper : IVmMapper<CreateCommentViewModel, Comment>
{
    public Comment Map(CreateCommentViewModel source)
    {
        var comment = new Comment()
        {
            AuthorId = source.AuthorId,
            Content = source.Content
        };
        return comment;
    }
}