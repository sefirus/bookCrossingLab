using Core.Entities;
using Core.ViewModels.BookViewModels;

namespace Core.Interfaces.Services;

public interface IBookCopyService
{
    Task CreateBookCopyAsync(SearchBookViewModel model, User creator);
    Task PutOnShelfAsync(int bookCopyId, User requestUser, int shelfId = 0);
    Task ReserveAsync(int bookCopyId, User requestUser);
    Task TakeFromShelfAsync(int bookCopyId, User requestUser);
}