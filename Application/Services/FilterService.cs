using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.ViewModels.CategoryViewModels;
using Core.ViewModels.FilterViewModels;
using Core.ViewModels.PublisherViewModels;
using Core.ViewModels.WriterViewModels;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class FilterService : IFilterService
{
    private readonly IRepository<Book> _bookRepository;
    
    public FilterService(IRepository<Book> bookRepository)
    {
        _bookRepository = bookRepository;
    }
    
    private IEnumerable<ReadWritersInFiltersVm> GetWriters(
        IList<Book> books)
    {
        var dictionary = new Dictionary<Writer, int>();
        foreach (var book in books)
        {
            foreach (var bw in book.BookWriters)
            {
                if (dictionary.ContainsKey(bw.Writer)) dictionary[bw.Writer]++;
                else dictionary.Add(bw.Writer, 1);
            }
        }
        var writerViewModels = new List<ReadWritersInFiltersVm>();
        foreach (var value in dictionary)
        {
            writerViewModels.Add(new ReadWritersInFiltersVm()
            {
                Count = value.Value,
                Id = value.Key.Id,
                FullName = value.Key.FullName
            });
        }

        return writerViewModels;
    }

    private IEnumerable<ReadCategoriesInFiltersVm> GetCategories(
        IList<Book> books)
    {
        var dictionary = new Dictionary<Category, int>();
        foreach (var book in books)
        {
            foreach (var bc in book.BookCategories)
            {
                if (dictionary.ContainsKey(bc.Category)) dictionary[bc.Category]++;
                else dictionary.Add(bc.Category, 1);
            }
        }
        var categoryViewModels = new List<ReadCategoriesInFiltersVm>();
        foreach (var value in dictionary)
        {
            categoryViewModels.Add(new ReadCategoriesInFiltersVm()
            {
                Count = value.Value,
                Id = value.Key.Id,
                Name = value.Key.Name
            });
        }

        return categoryViewModels;
    }

    private IEnumerable<ReadPublishersInFiltersVm> GetPublishers(IList<Book> books)
    {
        var dictionary = new Dictionary<Publisher, int>();
        foreach (var book in books)
        {
            if (dictionary.ContainsKey(book.Publisher)) dictionary[book.Publisher]++;
            else dictionary.Add(book.Publisher, 1);
        }
        var publisherViewModels = new List<ReadPublishersInFiltersVm>();
        foreach (var value in dictionary)
        {
            publisherViewModels.Add(new ReadPublishersInFiltersVm()
            {
                Count = value.Value,
                Id = value.Key.Id,
                Name = value.Key.Name
            });
        }

        return publisherViewModels;
    }

    private (int MaxCount, int MinCount, List<string> Languages) GetBookParams(
        IList<Book> books)
    {
        int max, min;
        max = min = books.First().PageCount;
        var languages = new List<string>();
        foreach (var book in books)
        {
            if (book.PageCount < min) min = book.PageCount;
            if (book.PageCount > max) max = book.PageCount;
            if (!languages.Contains(book.Language))
            {
                languages.Add(book.Language);
            }
        }

        return (max, min, languages);
    }

    public async Task<BookFiltersViewModel> GetBookFiltersAsync(
        Expression<Func<Book,bool>>? filter = null)
    {
        var books = await _bookRepository.QueryAsync(
            filter: filter,
            include: query => query
                .Include(b => b.Publisher)
                .Include(b => b.BookWriters)
                .ThenInclude(bw => bw.Writer)
                .Include(b => b.BookCategories)
                .ThenInclude(bc => bc.Category));

        var filters = GetBookFilters(books);
        return filters;
    }

    public BookFiltersViewModel GetBookFilters(IList<Book> books)
    {
        
        var bookFilters = GetBookParams(books);
        var filters = new BookFiltersViewModel()
        {
            Writers =  GetWriters(books),
            Categories = GetCategories(books),
            Publishers = GetPublishers(books),
            MaxPageCount = bookFilters.MaxCount,
            MinPageCount = bookFilters.MinCount,
            Languages = bookFilters.Languages
        };
        return filters;    }
}