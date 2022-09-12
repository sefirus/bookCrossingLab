using Core.Entities;
using Core.Interfaces.Mappers;
using Core.ViewModels.WriterViewModels;

namespace WebApi.Mappers.WriterMappers;

public class ReadEmbeddedWriterVmMapper : IVmMapper<Writer, ReadEmbeddedWriterVm>
{
    public ReadEmbeddedWriterVm Map(Writer source)
    {
        var vm = new ReadEmbeddedWriterVm()
        {
            Id = source.Id,
            FullName = source.FullName
        };
        return vm;
    }
}