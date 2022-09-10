using Core.Entities;
using Core.ViewModels.BookViewModels;

namespace Core.Interfaces.Services;

public interface IBookApiService
{
    Task<IEnumerable<SearchBookViewModel>> SearchBookAsync(string request);
    Task<Book> AddBookToLibraryAsync(SearchBookViewModel viewModel);   
}