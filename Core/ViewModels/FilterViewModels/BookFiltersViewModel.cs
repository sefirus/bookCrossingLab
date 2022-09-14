using Core.ViewModels.CategoryViewModels;
using Core.ViewModels.PublisherViewModels;
using Core.ViewModels.WriterViewModels;

namespace Core.ViewModels.FilterViewModels;

public class BookFiltersViewModel
{
    public IEnumerable<ReadPublishersInFiltersVm> Publishers { get; set; }
    public IEnumerable<ReadWritersInFiltersVm> Writers { get; set; }
    public IEnumerable<ReadCategoriesInFiltersVm> Categories { get; set; }
    public IEnumerable<string> Languages { get; set; }
    public int MaxPageCount { get; set; }
    public int MinPageCount { get; set; }
}