using Core.ViewModels.FilterViewModels;

namespace Core.ViewModels.BookViewModels;

public class FilteredPagedBooksVm
{
    public PagedViewModel<ReadBookViewModel> Books { get; set; } 
    public BookFiltersViewModel Filters { get; set; } 
}