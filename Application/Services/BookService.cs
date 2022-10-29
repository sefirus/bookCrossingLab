using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Pagination;
using Core.Pagination.Parameters;
using F23.StringSimilarity;
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
    
    public async Task<Book> GetBookByGoogleApiIdAsync(string googleApiId)
    {
        var book = await _bookRepository.GetFirstOrThrowAsync(
            filter: book => book.GoogleApiId == googleApiId,
            include: query => query.Include(b => b.Comments));
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

    private bool PassesPublisherFilter(HashSet<int> publisherIds, Book book)
    {
        return publisherIds.Count == 0 || publisherIds.Contains(book.PublisherId);
    }

    private bool PassesWriterFilter(HashSet<int> writerIds, Book book)
    {
        return writerIds.Count == 0 
               || book.BookWriters.Any(bw => writerIds.Contains(bw.WriterId));
    }

    private bool PassesCategoryFilter(HashSet<int> categoryIds, Book book)
    {
        return categoryIds.Count == 0 
               || book.BookCategories.Any(bc => categoryIds.Contains(bc.CategoryId));
    }

    private bool PassesLanguageFilter(HashSet<string> languages, Book book)
    {
        return languages.Count == 0 || languages.Contains(book.Language);
    }

    private bool PassesSearch(string? query, Book book, JaroWinkler comparer)
    {
        var normalizedTitle = book.Title.ToUpper();
        var normalizedDesc = book.Description.ToUpper();
        var result = string.IsNullOrEmpty(query)
               || normalizedTitle.Contains(query)
               || query.Contains(normalizedTitle)
               || normalizedDesc.Contains(query)
               || query.Contains(normalizedDesc)
               || comparer.Similarity(query, normalizedTitle) > 0.60
               || comparer.Similarity(query, normalizedDesc) > 0.60;
        return result;
    }
    
    public async Task<PagedList<Book>> GetFilteredBooksAsync(BookParameters parameters)
    {
        var books = await GetFullyIncludedBooksAsync();
        var jw = new JaroWinkler();
        var publisherIds = parameters.PublisherIds.ToHashSet();
        var writerIds = parameters.WriterIds.ToHashSet();
        var categoryIds = parameters.CategoryIds.ToHashSet();
        var languages = parameters.Language.ToHashSet();
        var normalizedQuery = parameters.FilterParam?.ToUpper();
        var filteredBooks = books.Where(book => PassesCategoryFilter(categoryIds, book)
                                    && PassesPublisherFilter(publisherIds, book)
                                    && PassesWriterFilter(writerIds, book)
                                    && PassesLanguageFilter(languages, book)
                                    && PassesSearch(normalizedQuery, book, jw)
                                    && book.PageCount >= parameters.MinPageCount 
                                    && book.PageCount <= parameters.MaxPageCount).ToList();
        var pagedBooks = filteredBooks.ToPagedList(parameters.PageNumber, parameters.PageSize);
        return pagedBooks;
    }

    private Task<IList<Book>> GetFullyIncludedBooksAsync(Expression<Func<Book, bool>>? filter = null)
    {
        return _bookRepository.QueryAsync( 
            filter: filter,
            include: query => query
                .Include(b => b.Publisher)
                .Include(b => b.BookWriters)
                    .ThenInclude(bw => bw.Writer)
                .Include(b => b.BookCategories)
                    .ThenInclude(bc => bc.Category)
                .Include(b => b.Pictures));
    }
    
    public async Task<IList<Book>> GetBooksByCategoryId(int categoryId)
    {
        var books = await GetFullyIncludedBooksAsync(book => book.BookCategories
                .Select(bc => bc.CategoryId)
                .Contains(categoryId));
        return books;
    }

    public async Task<IList<Book>> GetBooksByWriterId(int writerId)
    {
        var books = await GetFullyIncludedBooksAsync(book => book.BookWriters
            .Select(bw => bw.WriterId)
            .Contains(writerId));
        return books;
    }
    
    public async Task<IList<Book>> GetBooksByPublisherId(int publisherId)
    {
        var books = await GetFullyIncludedBooksAsync(book => book.PublisherId == publisherId);
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