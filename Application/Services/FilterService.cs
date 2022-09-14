using Core.Entities;
using Core.Interfaces.Repositories;
using Core.ViewModels.FilterViewModels;
using Core.ViewModels.ShelfViewModels;
using Core.ViewModels.WriterViewModels;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class FilterService
{
    private readonly IRepository<BookWriter> _bookWriterRepository;
    private readonly IRepository<Publisher> _publisherRepository;
    private readonly IRepository<BookCategory> _bookCategoryRepository;
    private readonly IRepository<Book> _bookRepository;


    public FilterService(
        IRepository<BookWriter> bookWriterRepository, 
        IRepository<Publisher> publisherRepository, 
        IRepository<BookCategory> bookCategoryRepository, 
        IRepository<Book> bookRepository)
    {
        _bookWriterRepository = bookWriterRepository;
        _publisherRepository = publisherRepository;
        _bookCategoryRepository = bookCategoryRepository;
        _bookRepository = bookRepository;
    }

    public async Task<BookFiltersViewModel> GetBookFiltersAsync(List<Book> books)
    {
        var filters = new BookFiltersViewModel();
        var writersGrouping = await _bookWriterRepository
            .GetQuery(include: query => query.Include(bw => bw.Writer))
            .GroupBy(bw => bw.Writer)
            .Select(g => new
            {
                g.Key.Id,
                g.Key.FullName,
                Count = g.Count()
            })
            .ToListAsync();
        filters.Writers = writersGrouping.Select(y => new ReadWritersInFiltersVm()
        {
            Count = y.Count,
            FullName = y.FullName,
            Id = y.Id
        });
        throw new NotImplementedException();
    }
}