using Core.Entities;
using Core.Pagination;
using Core.Pagination.Parameters;
using Core.ViewModels;

namespace Core.Interfaces.Services;

public interface IShelfService
{
    public Task<PagedList<Shelf>> GetPagedShelvesAsync(ParametersBase parameters);
    public Task AddShelfAsync(Shelf shelf);
    public Task DeleteShelfByIdAsync(int shelfId);
    public Task<IEnumerable<Shelf>> GetShelvesInAreaAsync(MapBoundaries boundaries);
    public Task<byte[]> GetShelfQrCodeFileAsync(int shelfId);
    public Task AddCommentOnShelfAsync(int shelfId, Comment newComment);
    public Task<Shelf> GetShelfByIdAsync(int shelfId);
}