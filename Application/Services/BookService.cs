using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Pagination;
using Core.Pagination.Parameters;
using Core.ViewModels.BookViewModels;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class BookService : IBookService
{
    private readonly IRepository<Book> _bookRepository;
    private readonly ICommentService _commentService;

    public BookService(
        IRepository<Book> bookRepository,
        ICommentService commentService)
    {

        _bookRepository = bookRepository;

        _commentService = commentService;
    }
    
    public async Task<Book> GetBookByViewModel(SearchBookViewModel viewModel)
    {
        var book = await _bookRepository.GetFirstOrDefaultAsync();
        return book;
    }

    public async Task<double> GetBookRate(int bookId)
    {
        var book = await _bookRepository.GetFirstOrThrowAsync(
            filter: b => b.Id == bookId,
            include: query => query.Include(b => b.Comments));
        var rate = GetBookRate(book);
        return rate;
    }

    public async Task AddCommentOnBookAsync(int bookId, Comment newComment)
    {
        var book = await _bookRepository.GetFirstOrThrowAsync(b => b.Id == bookId);
        newComment.BookId = bookId;
        newComment.Book = book;
        await _commentService.CreateCommentAsync(newComment);
    }

    public Task<PagedList<Book>> GetFilteredBooksAsync(BookParameters parameters)
    {
        throw new NotImplementedException();
    }

    public double GetBookRate(Book book)
    {
        double rate;
        try
        {
            rate = book.Comments.Average(c => c.Rate);
        }
        catch (InvalidOperationException)
        {
            rate = 0;
        }
        
        return rate;
    }
}