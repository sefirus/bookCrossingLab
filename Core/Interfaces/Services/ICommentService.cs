using Core.Entities;

namespace Core.Interfaces.Services;

public interface ICommentService
{
    public Task CreateCommentAsync(Comment newComment);
}