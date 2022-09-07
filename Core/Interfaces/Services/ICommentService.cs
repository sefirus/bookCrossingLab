using System.Linq.Expressions;
using Core.Entities;
using Core.Pagination;
using Core.Pagination.Parameters;

namespace Core.Interfaces.Services;

public interface ICommentService
{
    public Task CreateCommentAsync(Comment newComment);
    public Task<PagedList<Comment>> GetPagedCommentsAsync(
        ParametersBase parameters,
        Expression<Func<Comment, bool>>? additionalFilter = null);
    public Task DeleteCommentAsync(int commentId, User actor);
    public Task UpdateCommentAsync(Comment newComment);
}