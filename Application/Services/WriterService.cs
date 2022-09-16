using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;

namespace Application.Services;

public class WriterService : IWriterService
{
    private readonly IRepository<Writer> _writerRepository;

    public WriterService(IRepository<Writer> writerRepository)
    {
        _writerRepository = writerRepository;
    }

    public async Task AddWriterAsync(Writer newWriter)
    {
        await _writerRepository.InsertAsync(newWriter);
        await _writerRepository.SaveChangesAsync();
    }

    public async Task UpdateWriterAsync(Writer newWriter)
    {
        var oldWriter = await _writerRepository.GetFirstOrThrowAsync(w => w.Id == newWriter.Id);
        oldWriter.Description = newWriter.Description;
        oldWriter.FullName = newWriter.FullName;
        //TODO: Add pictures after azure is implemented
        await _writerRepository.SaveChangesAsync();
    }

    public async Task DeleteWriterAsync(int writerId)
    {
        var writerToDelete = await _writerRepository.GetFirstOrThrowAsync(w => w.Id == writerId);
        _writerRepository.Delete(writerToDelete);
        await _writerRepository.SaveChangesAsync();
    }

    public async Task<Writer> GetWriterByIdAsync(int writerId)
    {
        var writer = await _writerRepository.GetFirstOrThrowAsync(w => w.Id == writerId);
        return writer;
    }
}