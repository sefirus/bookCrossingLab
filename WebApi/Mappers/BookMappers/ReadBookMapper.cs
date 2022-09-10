using Core.Entities;
using Core.Interfaces.Mappers;
using Core.ViewModels.BookViewModels;

namespace WebApi.Mappers.BookMappers;

public class ReadBookMapper : IVmMapper<Book, ReadBookViewModel>
{
    public ReadBookViewModel Map(Book source)
    {
        var vm = new ReadBookViewModel()
        {
            Id = source.Id,
            Title = source.Title,
            Description = source.Description,
            Isbn = source.Isbn,
            Language = source.Language,
            PageCount = source.PageCount,
            //Rate = source.
        };
        return vm;
    }
}