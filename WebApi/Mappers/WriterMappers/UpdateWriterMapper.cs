using Core.Entities;
using Core.Interfaces.Mappers;
using Core.ViewModels.WriterViewModels;

namespace WebApi.Mappers.WriterMappers;

public class UpdateWriterMapper : IVmMapper<UpdateWriterViewModel, Writer>
{
    public Writer Map(UpdateWriterViewModel source)
    {
        var writer = new Writer()
        {
            Id = source.Id,
            FullName = source.FullName,
            Description = source.Description
        };
        return writer;
    }
}