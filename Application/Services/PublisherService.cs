using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;

namespace Application.Services;

public class PublisherService : IPublisherService
{
    private readonly IRepository<Publisher> _publisherRepository;

    public PublisherService(IRepository<Publisher> publisherRepository)
    {
        _publisherRepository = publisherRepository;
    }

    public async Task AddPublisherAsync(Publisher newPublisher)
    {
        await _publisherRepository.InsertAsync(newPublisher);
        await _publisherRepository.SaveChangesAsync();
    }

    public async Task UpdatePublisherAsync(Publisher newPublisher)
    {
        var oldPublisher = await _publisherRepository.GetFirstOrThrowAsync(p => p.Id == newPublisher.Id);
        oldPublisher.Name = newPublisher.Name;
        oldPublisher.Description = newPublisher.Description;
        //TODO: Add pictures after azure is implemented
        await _publisherRepository.SaveChangesAsync();
    }

    public async Task DeletePublisherAsync(int publisherId)
    {
        var publisherToDelete = await _publisherRepository.GetFirstOrThrowAsync(p => p.Id == publisherId);
        _publisherRepository.Delete(publisherToDelete);
        await _publisherRepository.SaveChangesAsync();
    }

    public async Task<Publisher> GetPublisherByIdAsync(int publisherId)
    {
        var publisher = await _publisherRepository.GetFirstOrThrowAsync(p => p.Id == publisherId);
        return publisher;
    }
}