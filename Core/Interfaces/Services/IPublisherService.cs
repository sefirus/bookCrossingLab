using Core.Entities;

namespace Core.Interfaces.Services;

public interface IPublisherService
{
    Task AddPublisherAsync(Publisher newPublisher, int userId, IEnumerable<string> imageLinks);
    Task UpdatePublisherAsync(Publisher newPublisher, int userId, IEnumerable<string> imageLinks);
    Task DeletePublisherAsync(int publisherId);
    Task<Publisher> GetPublisherByIdAsync(int publisherId);
}