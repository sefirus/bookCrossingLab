using Core.Entities;
using Core.Interfaces.Mappers;
using Core.Interfaces.Services;
using Core.ViewModels.BookViewModels;
using Core.ViewModels.PublisherViewModels;
using Core.ViewModels.WriterViewModels;

namespace WebApi.Mappers.BookMappers;

public class ReadBookMapper : IVmMapper<Book, ReadBookViewModel>
{
    private readonly IBookService _bookService;
    private readonly IEnumerableVmMapper<Writer, ReadEmbeddedWriterVm> _writersMapper;
    private readonly IVmMapper<Publisher, ReadEmbeddedPublisherVm> _publisherMapper;

    public ReadBookMapper(
        IBookService bookService, 
        IEnumerableVmMapper<Writer, ReadEmbeddedWriterVm> writersMapper, 
        IVmMapper<Publisher, ReadEmbeddedPublisherVm> publisherMapper)
    {
        _bookService = bookService;
        _writersMapper = writersMapper;
        _publisherMapper = publisherMapper;
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
        if (source.BookWriters is not null)
        {
            vm.Writers = _writersMapper.Map(source.BookWriters.Select(bw => bw.Writer));
        }
        if (source.Publisher is not null)
        {
            vm.Publisher = _publisherMapper.Map(source.Publisher);
        }

        if (source.Pictures is not null && source.Pictures.Any())
        {
            vm.PictureLink = source.Pictures
                .OrderBy(p => p.FullPath)
                .FirstOrDefault()!.FullPath;
        }
        return vm;
    }
}