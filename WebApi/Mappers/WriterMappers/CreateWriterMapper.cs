using Core.Entities;
using Core.Interfaces.Mappers;
using Core.ViewModels.WriterViewModels;

namespace WebApi.Mappers.WriterMappers;

public class CreateWriterMapper : IVmMapper<CreateWriterViewModel, Writer>
{
    public Writer Map(CreateWriterViewModel source)
    {
        var writer = new Writer()
        {
            FullName = source.FullName,
            Description = source.Description
        };
        return writer;
    }
}