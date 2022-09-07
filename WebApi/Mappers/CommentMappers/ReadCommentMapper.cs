using Core.Entities;
using Core.Interfaces.Mappers;
using Core.ViewModels.CommentViewModels;

namespace WebApi.Mappers.CommentMappers;

public class ReadCommentMapper : IVmMapper<Comment, ReadCommentViewModel>
{
    public ReadCommentViewModel Map(Comment source)
    {
        var vm = new ReadCommentViewModel()
        {
            AuthorId = source.AuthorId,
            AuthorName = source.Author.FirstName + ' ' + source.Author.LastName,
            CreatedAt = source.CreatedAt,
            Edited = source.Edited,
            Id = source.Id,
            Content = source.Content,
            Rate = source.Rate
        };
        return vm;
    }
}