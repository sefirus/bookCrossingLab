using Core.Entities;
using Core.Interfaces.Mappers;
using Core.ViewModels.PublisherViewModels;

namespace WebApi.Mappers.PublisherMappers;

public class ReadPublisherMapper : IVmMapper<Publisher, ReadPublisherViewModel>
{
    public ReadPublisherViewModel Map(Publisher source)
    {
        var vm = new ReadPublisherViewModel()
        {
            Id = source.Id,
            Name = source.Name,
            Description = source.Description,
            Pictures = source.Pictures.Select(p => p.FullPath)
        };
        return vm;
    }
}