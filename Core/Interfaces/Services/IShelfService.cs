using Core.Entities;
using Core.Pagination;
using Core.Pagination.Parameters;

namespace Core.Interfaces.Services;

public interface IShelfService
{
    public Task<PagedList<Shelf>> GetPagedShelvesAsync(ParametersBase parameters);
    public Task AddShelfAsync(Shelf shelf);
    public Task DeleteShelfAsync(Shelf shelf);
    public Task<IEnumerable<Shelf>> GetShelvesInAreaAsync(
        double northBound, double eastBound, double southBound, double westBound);
}