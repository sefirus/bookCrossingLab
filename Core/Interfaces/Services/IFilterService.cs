using System.Linq.Expressions;
using Core.Entities;
using Core.ViewModels.FilterViewModels;

namespace Core.Interfaces.Services;

public interface IFilterService
{
    Task<BookFiltersViewModel> GetBookFiltersAsync(Expression<Func<Book, bool>>? filter = null);
    BookFiltersViewModel GetBookFilters(IList<Book> books);
}