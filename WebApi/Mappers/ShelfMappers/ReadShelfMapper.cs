using Core.Entities;
using Core.Interfaces.Mappers;
using Core.ViewModels.ShelfViewModels;

namespace WebApi.Mappers.ShelfMappers;

public class ReadShelfMapper : IVmMapper<Shelf, ReadShelfViewModel>
{
    public ReadShelfViewModel Map(Shelf source)
    {
        var shelfVm = new ReadShelfViewModel()
        {
            Id = source.Id,
            Title = source.Title,
            FormattedAddress = source.FormattedAddress,
            Latitude = source.Latitude,
            Longitude = source.Longitude,
            CreatedAt = source.CreatedAt
        };
        if (source.Pictures is not null)
        {
            shelfVm.Pictures = source.Pictures.Select(p => p.FullPath);
        }
        return shelfVm;
    }
}