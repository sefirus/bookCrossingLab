using Core.Entities;
using Core.Pagination;
using Core.Pagination.Parameters;
using Core.ViewModels;
using Microsoft.EntityFrameworkCore.Query;

namespace Core.Interfaces.Services;

public interface IShelfService
{
    public Task<PagedList<Shelf>> GetPagedShelvesAsync(ParametersBase parameters);
    public Task AddShelfAsync(Shelf shelf);
    public Task DeleteShelfByIdAsync(int shelfId);
    public Task<IEnumerable<Shelf>> GetShelvesInAreaAsync(MapBoundaries boundaries);
}