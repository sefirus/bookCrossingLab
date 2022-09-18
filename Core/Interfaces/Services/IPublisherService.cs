using Core.Entities;

namespace Core.Interfaces.Services;

public interface IPublisherService
{
    Task AddPublisherAsync(Publisher newPublisher);
    Task UpdatePublisherAsync(Publisher newPublisher);
    Task DeletePublisherAsync(int publisherId);
    Task<Publisher> GetPublisherByIdAsync(int publisherId);
}