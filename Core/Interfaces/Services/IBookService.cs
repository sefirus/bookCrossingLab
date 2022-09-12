using Core.Entities;
using Core.Pagination;
using Core.Pagination.Parameters;
using Core.ViewModels.BookViewModels;

namespace Core.Interfaces.Services;

public interface IBookService
{
    Task<Book> GetBookByViewModel(SearchBookViewModel viewModel);
    double GetBookRate(Book book);
    Task<double> GetBookRate(int bookId);
    Task AddCommentOnBookAsync(int bookId, Comment newComment);
    Task<PagedList<Book>> GetFilteredBooksAsync(BookParameters parameters);
}