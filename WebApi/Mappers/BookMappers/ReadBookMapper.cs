using Core.Entities;
using Core.Interfaces.Mappers;
using Core.Interfaces.Services;
using Core.ViewModels.BookViewModels;

namespace WebApi.Mappers.BookMappers;

public class ReadBookMapper : IVmMapper<Book, ReadBookViewModel>
{
    private readonly IBookService _bookService;

    public ReadBookMapper(IBookService bookService)
    {
        _bookService = bookService;
    }

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
            Rate = _bookService.GetBookRate(source)
        };
        return vm;
    }
}