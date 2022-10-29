using Core.Entities;
using Core.Enums;
using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.ViewModels.BookViewModels;
using Core.ViewModels.BookViewModels.GoogleBookApiRequests;
using F23.StringSimilarity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Application.Services;

public class BookApiService : IBookApiService
{
    private readonly IConfiguration _configuration;
    private readonly IHttpClientFactory _clientFactory;
    private readonly IRepository<Book> _bookRepository;
    private readonly IRepository<Category> _categoryRepository;
    private readonly IRepository<Publisher> _publisherRepository;
    private readonly IRepository<Writer> _writerRepository;
    private readonly ILoggerManager _logger;

    public BookApiService(
        IConfiguration configuration, 
        IHttpClientFactory clientFactory, 
        IRepository<Book> bookRepository, 
        IRepository<Category> categoryRepository, 
        IRepository<Publisher> publisherRepository, 
        IRepository<Writer> writerRepository, 
        ILoggerManager logger)
    {
        _configuration = configuration;
        _clientFactory = clientFactory;
        _bookRepository = bookRepository;
        _categoryRepository = categoryRepository;
        _publisherRepository = publisherRepository;
        _writerRepository = writerRepository;
        _logger = logger;
    }

    private List<SearchBookViewModel> MapSearchBookViewModels(BookApiSearchResponse bookApiSearchResponse)
    {
        var searchBookViewModels = new List<SearchBookViewModel>();
        foreach (var volume in bookApiSearchResponse.Items)
        {
            var volumeAuthors = string.Empty;
            var authorsList = volume.VolumeInfo.Authors.ToList();
            if (authorsList.Count > 0)
            {
                for (int i = 0; i < authorsList.Count - 1; i++)
                {
                    volumeAuthors = $"{volumeAuthors}{authorsList[i]}, ";
                }
                volumeAuthors = $"{volumeAuthors}{authorsList.Last()}";
            }

            searchBookViewModels.Add(new SearchBookViewModel()
            {
                GoogleApiId = volume.Id,
                ThumbnailLink = volume.VolumeInfo.ImageLinks?.Thumbnail,
                Title = volume.VolumeInfo.Title,
                Authors = volumeAuthors,
                SearchResultType = SearchResultType.GoogleBookApi
            });
        }

        return searchBookViewModels;
    }
    
    private async Task<IEnumerable<SearchBookViewModel>> SearchInApiAsync(string uri)
    {
        var httpClient = _clientFactory.CreateClient();
        var response = await httpClient.GetStringAsync(uri);
        var tempResponse = JsonConvert.DeserializeObject<BookApiSearchResponse>(response);
        
        if (tempResponse.TotalItems == 0)
        {
            return Enumerable.Empty<SearchBookViewModel>();
        }
        
        var searchResults = MapSearchBookViewModels(tempResponse);

        return searchResults.Take(10);
    }

    private IEnumerable<SearchBookViewModel> MapBooks(IEnumerable<Book> books)
    {
        var searchResults = new List<SearchBookViewModel>();
        foreach (var book in books)
        {
            var bookAuthors = string.Empty;
            var authorsList = book.BookWriters.Select(bw => bw.Writer).ToList();
            if (authorsList.Count > 0)
            {
                bookAuthors = $"{bookAuthors}{authorsList.Last().FullName}";
                for (int i = 0; i < authorsList.Count - 1; i++)
                {
                    bookAuthors = $"{bookAuthors}{authorsList[i].FullName}, ";
                }
            }

            var vm = new SearchBookViewModel();
            vm.Title = book.Title;
            vm.InternalId = book.Id;
            vm.GoogleApiId = book.GoogleApiId;
            vm.Authors = bookAuthors;
            vm.SearchResultType = SearchResultType.Database;
            vm.ThumbnailLink = book.Pictures.FirstOrDefault()?.FullPath; 
            searchResults.Add(vm);
        }

        return searchResults;
    }

    private bool ContainsAuthor(string request, Book book, JaroWinkler comparer)
    {
        var result = book.BookWriters
            .Select(bw => bw.Writer)
            .Any(w => comparer.Similarity(request, w.FullName) > 0.55);
        return result;
    }

    private bool ContainsTitle(string request, Book book, JaroWinkler comparer)
    {
        var result = comparer.Similarity(request, book.Title) > 0.55 
                     || comparer.Similarity(request, book.Description) > 0.55;
        return result;
    }

    private async Task<(IEnumerable<SearchBookViewModel> FoundBooks, HashSet<string> googleApiIds)> SearchInDbAsync(string request)
    {
        var books = await _bookRepository.QueryAsync(include: prop =>
            prop.Include(b => b.BookWriters)
                .ThenInclude(ba => ba.Writer)
                .Include(b => b.Pictures));
        var jw = new JaroWinkler();
        var foundIds = new HashSet<string>();
        var filteredBooks = new List<Book>();
        foreach (var book in books)
        {
            if (ContainsAuthor(request, book, jw) || ContainsTitle(request, book, jw))
            {
                filteredBooks.Add(book);
                foundIds.Add(book.GoogleApiId);
            }
        }
        var mappedBooks = MapBooks(filteredBooks);
        return (mappedBooks, foundIds);
    }

    public async Task<IEnumerable<SearchBookViewModel>> SearchBookAsync(string request)
    {
        if (string.IsNullOrEmpty(request))
        {
            return Enumerable.Empty<SearchBookViewModel>();
        }
        var bookRequestUri = $"{_configuration["ApiAddresses:GoogleBooksUrl"]}?q=intitle:{request}";
        var authorRequestUri = $"{_configuration["ApiAddresses:GoogleBooksUrl"]}?q=inauthor:{request}";
        var dbSearchResults = await SearchInDbAsync(request);
        var partialSearchResults = await Task.WhenAll(
            SearchInApiAsync(bookRequestUri),
            SearchInApiAsync(authorRequestUri));
        List<SearchBookViewModel> result = dbSearchResults.FoundBooks.ToList();
        _logger.LogInfo("Found books from api and database");
        foreach (var res in partialSearchResults)
        {
            foreach (var foundBook in res)
            {
                if (!dbSearchResults.googleApiIds.Contains(foundBook.GoogleApiId))
                {
                    result.Add(foundBook);
                }
            }
        }
        return result;
    }

    private List<string> FindMissingProperties(VolumeViewModel volumeViewModel)
    {
        var missingProperties = new List<string>();
        foreach (var prop in volumeViewModel.VolumeInfo.GetType().GetProperties())
        {
            switch (prop.GetValue(volumeViewModel.VolumeInfo))
            {
                case string property:
                    if (string.IsNullOrEmpty(property))
                    {
                        missingProperties.Add(prop.Name);
                    }
                    break;
                case IEnumerable<string> property:
                    if (!property.Any())
                    {
                        missingProperties.Add(prop.Name);
                    }
                    break;
                case ImageLinksViewModel imageLinksProperty:
                    var notNullImages = new Dictionary<string, string>();
                    foreach (var imageLinkProp in imageLinksProperty.GetType().GetProperties())
                    {
                        var value = imageLinkProp.GetValue(imageLinksProperty) as string;
                        if (!string.IsNullOrEmpty(value))
                        {
                            notNullImages.Add(imageLinkProp.Name, value);
                        }
                    }
                    if (!notNullImages.Any())
                    {
                        missingProperties.Add(prop.Name);
                    }
                    break;
            }
        }

        return missingProperties;
    }

    private async Task<IEnumerable<BookCategory>> MapCategories(
        IEnumerable<string> categoryNames, 
        Book creatingBook)
    {
        var result = new List<BookCategory>();
        var categories = await _categoryRepository.QueryAsync();
        foreach (var categoryName in categoryNames)
        {
            var words = categoryName
                .ToUpper()
                .Split('/', StringSplitOptions.TrimEntries)
                .Reverse();
            foreach (var word in words)
            {
                foreach (var category in categories)
                {
                    if (category.Name.ToUpper().Contains(word))
                    {
                        result.Add(new BookCategory()
                        {
                            Book = creatingBook,
                            CategoryId = category.Id,
                            Category = category
                        });
                    }
                }
            }
        }

        if (result.Count != 0) 
            result = result.GroupBy(bc => bc.CategoryId)
            .Select(grouping => grouping.First())
            .ToList();
        
        var uncategorized = categories.FirstOrDefault(cat => cat.Name == "Uncategorized")!; 
        result.Add(new BookCategory()
        {
            Book = creatingBook,
            Category = uncategorized,
            CategoryId = uncategorized.Id
        });
        return result;
    }

    private IEnumerable<Picture> MapPictures(
        ImageLinksViewModel imageLinksViewModel,
        Book creatingBook)
    {
        var result = new List<Picture>(); 
        foreach (var imageLinkProp in imageLinksViewModel.GetType().GetProperties())
        {
            var value = imageLinkProp.GetValue(imageLinksViewModel) as string;
            if (!string.IsNullOrEmpty(value))
            {
                result.Add(new Picture()
                {
                    Book = creatingBook,
                    FullPath = value
                });
            }
        }

        return result;
    }

    private async Task<Publisher> MapPublisher(string name)
    {
        var possiblePublisher = (await _publisherRepository
            .QueryAsync())
            .FirstOrDefault(pub => pub.Name.ToUpper() == name.ToUpper());
        if (possiblePublisher is null)
        {
            var newPublisher = new Publisher()
            {
                Name = name,
            };
            await _publisherRepository.InsertAsync(newPublisher);
            await _publisherRepository.SaveChangesAsync();
            return newPublisher;
        }

        return possiblePublisher;
    }

    private async Task<ICollection<BookWriter>> MapBookWriters(
        IEnumerable<string> bookAuthors,
        Book creatingBook)
    {
        var writers = await _writerRepository.QueryAsync();
        var jw = new JaroWinkler();
        ICollection<BookWriter> resultCollection = new List<BookWriter>();
        foreach (var authorName in bookAuthors)
        {
            bool hasFound = false;
            foreach (var writer in writers)
            {
                if (jw.Similarity(writer.FullName, authorName) > 0.65)
                {
                    hasFound = true;
                    resultCollection.Add(new BookWriter()
                    {
                        Book = creatingBook,
                        WriterId = writer.Id,
                        Writer = writer
                    });
                }
            }
            if (hasFound) continue;
            
            var newWriter = new Writer()
            {
                FullName = authorName
            };
            resultCollection.Add(new BookWriter()
            {
                Book = creatingBook,
                Writer = newWriter
            });
            newWriter.BookWriters = resultCollection;
        }

        return resultCollection;
    }

    private string MapIsbn(IEnumerable<IndustryIdentifier> identifiers)
    {
        var isbn = identifiers.First().Identifier;
        return isbn;
    }

    private async Task<Book> MapVolumeToBookAsync(VolumeViewModel volumeViewModel)
    {
        var missingProperties = FindMissingProperties(volumeViewModel);
        if (missingProperties.Any())
        {
            throw new VolumeIncompleteException(missingProperties, volumeViewModel);
        }
        Book newBook = new Book();
        newBook.Title = volumeViewModel.VolumeInfo.Title;
        newBook.GoogleApiId = volumeViewModel.Id;
        newBook.Description = volumeViewModel.VolumeInfo.Description;
        newBook.Language = volumeViewModel.VolumeInfo.Language;
        newBook.Pictures = MapPictures(volumeViewModel.VolumeInfo.ImageLinks!, newBook);
        newBook.Publisher = await MapPublisher(volumeViewModel.VolumeInfo.Publisher);
        newBook.BookWriters = await MapBookWriters(volumeViewModel.VolumeInfo.Authors, newBook);
        newBook.BookCategories = await MapCategories(volumeViewModel.VolumeInfo.Categories, newBook);
        newBook.Isbn = MapIsbn(volumeViewModel.VolumeInfo.IndustryIdentifiers);
        newBook.PageCount = volumeViewModel.VolumeInfo.PageCount;
        
        return newBook;
    }
    
    public async Task<Book> AddBookToLibraryAsync(SearchBookViewModel viewModel)
    {
        if (viewModel.SearchResultType == SearchResultType.Database)
        {
            throw new InvalidOperationException();
        }

        var bookUrl = $"{_configuration["ApiAddresses:GoogleBooksUrl"]}/{viewModel.GoogleApiId}";
        var client = _clientFactory.CreateClient();
        var response = await client.GetStringAsync(bookUrl);
        var volume = JsonConvert.DeserializeObject<VolumeViewModel>(response);
        var newBook = await MapVolumeToBookAsync(volume);
        await _bookRepository.InsertAsync(newBook);
        await _bookRepository.SaveChangesAsync();
        return newBook;
    }
}