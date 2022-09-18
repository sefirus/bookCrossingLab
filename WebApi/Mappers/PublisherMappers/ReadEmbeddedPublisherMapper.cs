using Core.Entities;
using Core.Interfaces.Mappers;
using Core.ViewModels.PublisherViewModels;

namespace WebApi.Mappers.PublisherMappers;

public class ReadEmbeddedPublisherMapper : IVmMapper<Publisher, ReadEmbeddedPublisherVm>
{
    public ReadEmbeddedPublisherVm Map(Publisher source)
    {
        var vm = new ReadEmbeddedPublisherVm()
        {
            Id = source.Id,
            Name = source.Name
        };
        return vm;
    }
}