using Core.Entities;
using Core.ViewModels.BookViewModels;

namespace Core.Interfaces.Services;

public interface IBookCopyService
{
    Task CreateBookCopyAsync(SearchBookViewModel model, User creator);
}