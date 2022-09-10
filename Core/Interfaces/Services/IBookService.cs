using Core.Entities;
using Core.ViewModels.BookViewModels;

namespace Core.Interfaces.Services;

public interface IBookService
{
    Task<Book> GetBookByViewModel(SearchBookViewModel viewModel);
    double GetBookRate(Book book);
    Task<double> GetBookRate(int bookId);

}