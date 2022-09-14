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
    private readonly IFilterService _filterService;

    public BookService(
        IRepository<Book> bookRepository,
        ICommentService commentService, 
        IFilterService filterService)
    {

        _bookRepository = bookRepository;
        _commentService = commentService;
        _filterService = filterService;
    }
    
    public async Task<Book> GetBookByViewModel(SearchBookViewModel viewModel)
    {
        var book = await _bookRepository.GetFirstOrThrowAsync();
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

    public async Task<PagedList<Book>> GetFilteredBooksAsync(BookParameters parameters)
    {
        throw new NotImplementedException();
    }

    public async Task<IList<Book>> GetBooksByCategoryId(int categoryId)
    {
        var books = await _bookRepository.QueryAsync(
            filter: book => book.BookCategories
                .Select(bc => bc.CategoryId)
                .Contains(categoryId),
            include: query => query
                .Include(b => b.Publisher)
                .Include(b => b.BookWriters)
                .ThenInclude(bw => bw.Writer)
                .Include(b => b.BookCategories)
                .ThenInclude(bc => bc.Category));
        return books;
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