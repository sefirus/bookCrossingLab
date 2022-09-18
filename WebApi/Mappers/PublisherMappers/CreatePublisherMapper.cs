using Core.Entities;
using Core.Interfaces.Mappers;
using Core.ViewModels.PublisherViewModels;

namespace WebApi.Mappers.PublisherMappers;

public class CreatePublisherMapper : IVmMapper<CreatePublisherViewModel, Publisher>
{
    public Publisher Map(CreatePublisherViewModel source)
    {
        var publisher = new Publisher()
        {
            Name = source.Name,
            Description = source.Description
        };
        return publisher;
    }
}