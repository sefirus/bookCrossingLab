using System.Linq.Expressions;
using Core.Entities;
using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Pagination;
using Core.Pagination.Parameters;
using Microsoft.EntityFrameworkCore;

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
    
    public async Task<PagedList<Comment>> GetPagedCommentsAsync(
        FilteredParameters parameters,
        Expression<Func<Comment, bool>>? additionalFilter = null)
    {
        var paramFilter = GetFilterQuery(parameters.FilterParam);
        Expression<Func<Comment, bool>>? finalFilter;

        if (additionalFilter is null || paramFilter is null)
        {
            finalFilter = additionalFilter ?? paramFilter;
        }
        else
        {
            var invokedExpr = Expression.Invoke(additionalFilter, paramFilter.Parameters);
            finalFilter = Expression.Lambda<Func<Comment, bool>>
                (Expression.AndAlso (paramFilter.Body, invokedExpr), paramFilter.Parameters);
        }

        var orderBy = GetOrderByQuery(parameters.OrderByParam);
        
        var procedures = await _commentRepository.GetPaged(
            parameters: parameters,
            filter: finalFilter,
            orderBy: orderBy,
            include: query => query.Include(c => c.Author));
        return procedures;
    }
    
    private static Expression<Func<Comment, bool>>? GetFilterQuery(string? filterParam)
    {
        Expression<Func<Comment, bool>>? filterQuery = null;
        if (filterParam is null) return filterQuery;
        var formattedFilter = filterParam.Trim().ToLower();
        filterQuery = c => c.Content.ToLower().Contains(formattedFilter)
                           || c.Rate.ToString() == filterParam;
        return filterQuery;
    }
    
    private static Func<IQueryable<Comment>, IOrderedQueryable<Comment>>? GetOrderByQuery(string? orderBy)
    {
        switch (orderBy)
        {
            case "Content": return query => query.OrderBy(c => c.Content);
            case "CreatedAt": return query => query.OrderBy(c => c.CreatedAt);
            case "Rate" : return query => query.OrderBy(c => c.Rate);
            default: return null; 
        }
    }

    public async Task UpdateCommentAsync(Comment newComment)
    {
        var oldComment = await _commentRepository.GetFirstOrThrowAsync(c => c.Id == newComment.Id);
        if (oldComment.AuthorId != newComment.AuthorId)
        {
            throw new BadRequestException("You cant edit this comment");
        }

        oldComment.Edited = true;
        oldComment.Content = newComment.Content;
        oldComment.Rate = newComment.Rate;
        await _commentRepository.SaveChangesAsync();
    }

    public async Task DeleteCommentAsync(int commentId, User actor)
    {
        var commentToDelete = await _commentRepository.GetFirstOrThrowAsync(c => c.Id == commentId);
        if (commentToDelete.AuthorId != actor.Id && actor.Role.Name is not ("SUPER ADMIN" or "POWER USER"))
        {
            throw new BadRequestException("You cant delete this comment");
        }
        _commentRepository.Delete(commentToDelete);
        await _commentRepository.SaveChangesAsync();
    }
}