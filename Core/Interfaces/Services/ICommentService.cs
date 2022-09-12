using System.Linq.Expressions;
using Core.Entities;
using Core.Pagination;
using Core.Pagination.Parameters;

namespace Core.Interfaces.Services;

public interface ICommentService
{
    Task CreateCommentAsync(Comment newComment);
    Task<PagedList<Comment>> GetPagedCommentsAsync(
        FilteredParameters parameters,
        Expression<Func<Comment, bool>>? additionalFilter = null);
    Task DeleteCommentAsync(int commentId, User actor);
    Task UpdateCommentAsync(Comment newComment);
}