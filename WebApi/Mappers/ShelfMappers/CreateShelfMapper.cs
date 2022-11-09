using Core.Entities;
using Core.Interfaces.Mappers;
using Core.ViewModels.ShelfViewModels;

namespace WebApi.Mappers.ShelfMappers;

public class CreateShelfMapper : IVmMapper<CreateShelfViewModel, Shelf>
{
    public Shelf Map(CreateShelfViewModel source)
    {
        var shelf = new Shelf()
        {
            Title = source.Title,
            FormattedAddress = source.FormattedAddress,
            Latitude = source.Latitude,
            Longitude = source.Longitude,
            Pictures = new List<Picture>()
            {
                new Picture(){ FullPath = source.PictureLink}
            }
        };
        return shelf;
    }
}