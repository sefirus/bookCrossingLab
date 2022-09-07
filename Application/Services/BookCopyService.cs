using System.Linq.Expressions;
using Core.Entities;
using Core.Enums;
using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Pagination;
using Core.Pagination.Parameters;
using Core.ViewModels.BookViewModels;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class BookCopyService : IBookCopyService
{
    private readonly IBookService _bookService;
    private readonly IRepository<BookCopy> _bookCopyRepository;
    private readonly IRepository<Shelf> _shelfRepository;

    public BookCopyService(
        IBookService bookService, 
        IRepository<BookCopy> bookCopyRepository, 
        IRepository<Shelf> shelfRepository)
    {
        _bookService = bookService;
        _bookCopyRepository = bookCopyRepository;
        _shelfRepository = shelfRepository;
    }
    
    public async Task CreateBookCopyAsync(SearchBookViewModel model, User creator)
    {
        Book baseBook; 
        if (model.SearchResultType == SearchResultType.GoogleBookApi)
        {
            baseBook = await _bookService.AddBookToLibraryAsync(model);
        }        
        else
        {
            baseBook = await _bookService.GetBookByViewModel(model);
        }
        var newBookCopy = new BookCopy()
        {
            BookId = baseBook.Id,
            Book = baseBook,
            State = BookCopyState.Maintained,
            CurrentUserId = creator.Id,
            CurrentUser = creator
        };
        await _bookCopyRepository.InsertAsync(newBookCopy);
        await _bookCopyRepository.SaveChangesAsync();
    }

    public async Task PutOnShelfAsync(int bookCopyId, User requestUser, int shelfId = 0)
    {
        var bookCopy = await _bookCopyRepository.GetFirstOrThrowAsync(bc => bc.Id == bookCopyId);
        if (bookCopy.State == BookCopyState.Vacant || bookCopy.CurrentUserId != requestUser.Id)
        {
            throw new BadRequestException("BookCopy is already on the shelf or maintained by another user");
        }

        bookCopy.State = BookCopyState.Vacant;
        bookCopy.CurrentUserId = null;
        bookCopy.CurrentUser = null;

        if (shelfId != 0)
        {
            var shelf = await _shelfRepository.GetFirstOrThrowAsync(sh => sh.Id == shelfId);
            bookCopy.CurrentShelfId = shelfId;
            bookCopy.CurrentShelf = shelf;
        }

        await _bookCopyRepository.SaveChangesAsync();
    }

    public async Task ReserveAsync(int bookCopyId, User requestUser)
    {
        var bookCopy = await _bookCopyRepository.GetFirstOrThrowAsync(bc => bc.Id == bookCopyId);
        if (bookCopy.State != BookCopyState.Vacant)
        {
            throw new BadRequestException("You cant reserve this book");
        }
        bookCopy.State = BookCopyState.Reserved;
        bookCopy.CurrentUserId = requestUser.Id;
        bookCopy.CurrentUser = requestUser;
        await _bookCopyRepository.SaveChangesAsync();
    }

    public async Task TakeFromShelfAsync(int bookCopyId, User requestUser)
    {
        var bookCopy = await _bookCopyRepository.GetFirstOrThrowAsync(bc => bc.Id == bookCopyId);

        if (bookCopy.State == BookCopyState.Vacant ||
            (bookCopy.State == BookCopyState.Reserved && bookCopy.CurrentUserId == requestUser.Id))
        {
            bookCopy.State = BookCopyState.Maintained;
            bookCopy.CurrentUserId = requestUser.Id;
            bookCopy.CurrentUser = requestUser;
            bookCopy.CurrentShelf = null;
            bookCopy.CurrentShelfId = null;
            await _bookCopyRepository.SaveChangesAsync();
        }
        else
        {
            throw new BadRequestException("You can`t take this book");
        }
    }
    
    public async Task<PagedList<BookCopy>> GetBookCopiesByShelfIdAsync(int shelfId, ParametersBase parameters)
    {
        await _shelfRepository.GetFirstOrThrowAsync(sh => sh.Id == shelfId);

        var bookCopies = await _bookCopyRepository.GetPaged(
            parameters: parameters,
            filter: GetFilterQuery(parameters.FilterParam, shelfId),
            orderBy: GetOrderByQuery(parameters.OrderByParam),
            include: query => query.Include(bc => bc.Book)
                .ThenInclude(book => book.BookWriters)
                .ThenInclude(bw => bw.Writer));
        return bookCopies;
    }
    
    private static Expression<Func<BookCopy, bool>>? GetFilterQuery(string? filterParam, int shelfId)
    {
        Expression<Func<BookCopy, bool>>? filterQuery = null;

        if (filterParam is null) return filterQuery;
        
        var formattedFilter = filterParam.Trim().ToLower();

        filterQuery = bc => (bc.Book.Title.ToLower().Contains(formattedFilter)
                             || bc.Book.Description.ToLower().Contains(formattedFilter)
                             || bc.Book.BookWriters
                                 .Select(bw => bw.Writer.FullName)
                                 .Any(name => name.ToLower().Contains(formattedFilter))
                             || GetBookCopyStateName(bc.State).ToLower().Contains(formattedFilter))
            && bc.CurrentShelfId == shelfId;

        return filterQuery;
    }

    private static string GetBookCopyStateName(BookCopyState state)
    {
        switch(state)
        {
            case BookCopyState.Maintained: return "Maintained";
            case BookCopyState.Reserved: return "Reserved";
            case BookCopyState.Vacant: return "Vacant";
            default: return string.Empty;
        }
    }

    private static Func<IQueryable<BookCopy>, IOrderedQueryable<BookCopy>>? GetOrderByQuery(string? orderBy)
    {
        switch (orderBy)
        {
            case "Title": return query => query.OrderBy(bc => bc.Book.Title);
            case "Description": return query => query.OrderBy(shelf => shelf.Book.Description);
            case "State" : return query => query.OrderBy(shelf => shelf.State);
            default: return null; 
        }
    }
}