using Core.Entities;
using Core.Pagination;
using Core.Pagination.Parameters;

namespace Core.Interfaces.Services;

public interface IBookService
{
    Task<Book> GetBookByGoogleApiIdAsync(string googleApiId);
    double GetBookRate(Book book);
    Task<double> GetBookRate(int bookId);
    Task AddCommentOnBookAsync(int bookId, Comment newComment);
    Task<PagedList<Book>> GetFilteredBooksAsync(BookParameters parameters);
    Task<IList<Book>> GetBooksByCategoryId(int categoryId);
    Task<IList<Book>> GetBooksByWriterId(int writerId);
    Task<IList<Book>> GetBooksByPublisherId(int publisherId);
}