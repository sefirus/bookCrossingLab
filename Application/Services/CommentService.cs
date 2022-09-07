using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;

namespace Application.Services;

public class CommentService : ICommentService
{
    private readonly IRepository<Comment> _commentRepository;
    private readonly IRepository<User> _userRepository;
    
    public CommentService(
        IRepository<Comment> commentRepository,
        IRepository<User> userRepository)
    {
        _commentRepository = commentRepository;
        _userRepository = userRepository;
    }

    public async Task CreateCommentAsync(Comment newComment)
    {
        var author = await _userRepository
            .GetFirstOrThrowAsync(user => user.Id == newComment.AuthorId && user.IsActive);

        newComment.Author = author;
        newComment.CreatedAt = DateTime.Now;
        newComment.Edited = false;
        await _commentRepository.InsertAsync(newComment);
        await _commentRepository.SaveChangesAsync();
    }
}