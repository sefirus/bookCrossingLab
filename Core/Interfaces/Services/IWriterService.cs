using Core.Entities;

namespace Core.Interfaces.Services;

public interface IWriterService
{
    Task AddWriterAsync(Writer newWriter);
    Task UpdateWriterAsync(Writer newWriter);
    Task DeleteWriterAsync(int writerId);
    Task<Writer> GetWriterByIdAsync(int writerId);
}