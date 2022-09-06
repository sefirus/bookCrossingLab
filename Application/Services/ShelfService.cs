using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using Core.Entities;
using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Pagination;
using Core.Pagination.Parameters;
using Core.ViewModels;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Services;

public class ShelfService : IShelfService
{
    private readonly IRepository<Shelf> _shelfRepository;
    private readonly IMemoryCache _memoryCache;

    public ShelfService(
        IRepository<Shelf> shelfRepository,
        IMemoryCache memoryCache)
    {
        _shelfRepository = shelfRepository;
        _memoryCache = memoryCache;
    }

    public async Task<IEnumerable<Shelf>> GetShelvesInAreaAsync(MapBoundaries boundaries)
    {
        var shelves = await _shelfRepository.QueryAsync(shelf =>
            shelf.Longitude <= boundaries.North
            && shelf.Longitude >= boundaries.South 
            && shelf.Latitude <= boundaries.East
            && shelf.Latitude >= boundaries.West);
        return shelves;
    }

    public async Task<PagedList<Shelf>> GetPagedShelvesAsync(ParametersBase parameters)
    {
        var filter = GetFilterQuery(parameters.FilterParam);
        var order = GetOrderByQuery(parameters.OrderByParam);
        
        var procedures = await _shelfRepository.GetPaged(
            parameters: parameters,
            filter: filter,
            orderBy: order);
        return procedures;
    }
    
    private static Expression<Func<Shelf, bool>>? GetFilterQuery(string? filterParam)
    {
        Expression<Func<Shelf, bool>>? filterQuery = null;

        if (filterParam is null) return filterQuery;
        
        var formattedFilter = filterParam.Trim().ToLower();

        filterQuery = sh => sh.FormattedAddress.ToLower().Contains(formattedFilter)
                            || sh.Title!.ToLower().Contains(formattedFilter);

        return filterQuery;
    }

    private static Func<IQueryable<Shelf>, IOrderedQueryable<Shelf>>? GetOrderByQuery(string? orderBy)
    {
        switch (orderBy)
        {
            case "Title": return query => query.OrderBy(shelf => shelf.Title);
            case "FormattedAddress": return query => query.OrderBy(shelf => shelf.FormattedAddress);
            default: return null; 
        }
    }

    public async Task AddShelfAsync(Shelf shelf)
    {
        //TODO: add image uploading like in articles of vetClinic
        shelf.CreatedAt = DateTime.Now;
        await _shelfRepository.InsertAsync(shelf);
        await _shelfRepository.SaveChangesAsync();
    }

    public async Task DeleteShelfByIdAsync(int shelfId)
    {
        var shelf = await _shelfRepository.GetFirstOrDefaultAsync(sh => sh.Id == shelfId);
        if (shelf is null)
        {
            throw new NotFoundException($"Shelf with id {shelfId} does not exist");
        }
        _shelfRepository.Delete(shelf);
        await _shelfRepository.SaveChangesAsync();
    }
}