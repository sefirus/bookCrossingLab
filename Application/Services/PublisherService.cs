using Core.Entities;
using Core.Enums;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class PublisherService : IPublisherService
{
    private readonly IRepository<Publisher> _publisherRepository;
    private readonly IRepository<Picture> _pictureRepository;
    private readonly IImageService _imageService;

    public PublisherService(
        IRepository<Publisher> publisherRepository, 
        IImageService imageService, 
        IRepository<Picture> pictureRepository)
    {
        _publisherRepository = publisherRepository;
        _imageService = imageService;
        _pictureRepository = pictureRepository;
    }

    public async Task AddPublisherAsync(Publisher newPublisher, int userId, IEnumerable<string> imageLinks)
    {
        var pictureList = _imageService.MapPictures(imageLinks);
        await _imageService.ClearUnusedImagesAsync(pictureList, userId, PictureOperationType.EditingPublisher);
        newPublisher.Pictures = pictureList;
        await _publisherRepository.InsertAsync(newPublisher);
        await _publisherRepository.SaveChangesAsync();
    }

    public async Task UpdatePublisherAsync(Publisher newPublisher, int userId, IEnumerable<string> imageLinks)
    {
        var oldPublisher = await _publisherRepository
            .GetFirstOrThrowAsync(
                filter: p => p.Id == newPublisher.Id,
                include: query => query.Include(publisher => publisher.Pictures));
        oldPublisher.Name = newPublisher.Name;
        oldPublisher.Description = newPublisher.Description;
        var pictureList = _imageService.MapPictures(imageLinks, oldPublisher.Pictures.ToList());
        await _imageService.ClearUnusedImagesAsync(pictureList, userId, PictureOperationType.EditingPublisher);
        await _imageService.ClearOutdatedImagesAsync(oldPublisher.Pictures.ToList(), pictureList);
        oldPublisher.Pictures = pictureList;
        await _publisherRepository.SaveChangesAsync();
    }

    public async Task DeletePublisherAsync(int publisherId)
    {
        var publisherToDelete = await _publisherRepository
            .GetFirstOrThrowAsync(
                filter: p => p.Id == publisherId,
                include: query => query.Include(p => p.Pictures));
        await _imageService.DeleteImagesAsync(publisherToDelete.Pictures.ToList());
        _publisherRepository.Delete(publisherToDelete);
        await _publisherRepository.SaveChangesAsync();
    }

    public async Task<Publisher> GetPublisherByIdAsync(int publisherId)
    {
        var publisher = await _publisherRepository.GetFirstOrThrowAsync(
            filter: p => p.Id == publisherId,
            include: query => query.Include(p => p.Pictures));
        return publisher;
    }
}