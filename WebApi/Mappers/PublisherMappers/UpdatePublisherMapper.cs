using Core.Entities;
using Core.Interfaces.Mappers;
using Core.ViewModels.PublisherViewModels;

namespace WebApi.Mappers.PublisherMappers;

public class UpdatePublisherMapper : IVmMapper<UpdatePublisherViewModel, Publisher>
{
    public Publisher Map(UpdatePublisherViewModel source)
    {
        var publisher = new Publisher()
        {
            Id = source.Id,
            Name = source.Name,
            Description = source.Description
        };
        return publisher;
    }
}