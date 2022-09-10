using Core.Entities;
using Core.Enums;
using Core.Exceptions;
using Core.Interfaces.Mappers;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.ViewModels.BookViewModels;
using Core.ViewModels.BookViewModels.GoogleBookApiRequests;
using F23.StringSimilarity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Application.Services;

public class BookService : IBookService
{
    private readonly IConfiguration _configuration;
    private readonly IHttpClientFactory _clientFactory;
    private readonly IRepository<Book> _bookRepository;
    private readonly IRepository<Category> _categoryRepository;
    private readonly IRepository<Publisher> _publisherRepository;
    private readonly IRepository<Writer> _writerRepository;
    private readonly ILoggerManager _logger;

    public BookService(
        IConfiguration configuration, 
        IHttpClientFactory clientFactory,
        IRepository<Book> bookRepository, 
        IRepository<Category> categoryRepository,
        ILoggerManager logger, 
        IRepository<Publisher> publisherRepository, 
        IRepository<Writer> writerRepository)
    {
        _configuration = configuration;
        _clientFactory = clientFactory;
        _bookRepository = bookRepository;
        _categoryRepository = categoryRepository;
        _logger = logger;
        _publisherRepository = publisherRepository;
        _writerRepository = writerRepository;
    }
    
    public async Task<Book> GetBookByViewModel(SearchBookViewModel viewModel)
    {
        var book = await _bookRepository.GetFirstOrDefaultAsync();
        return book;
    }

    public async Task<double> GetBookRate(int bookId)
    {
        var book = await _bookRepository.GetFirstOrThrowAsync(
            filter: b => b.Id == bookId,
            include: query => query.Include(b => b.Comments));
        var rate = GetBookRate(book);
        return rate;
    }

    public double GetBookRate(Book book)
    {
        var rate = book.Comments.Average(c => c.Rate);
        return rate;
    }
}