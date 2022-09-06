using Core.Entities;
using Core.Enums;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.ViewModels.BookViewModels;

namespace Application.Services;

public class BookCopyService : IBookCopyService
{
    private readonly IBookService _bookService;
    private readonly IRepository<BookCopy> _bookCopyRepository;

    public BookCopyService(
        IBookService bookService, 
        IRepository<BookCopy> bookCopyRepository)
    {
        _bookService = bookService;
        _bookCopyRepository = bookCopyRepository;
    }
    
    public async Task AddBookCopy(
        SearchBookViewModel model,
        User creator)
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
}