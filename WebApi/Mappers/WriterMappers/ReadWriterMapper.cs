using Core.Entities;
using Core.Interfaces.Mappers;
using Core.ViewModels.WriterViewModels;

namespace WebApi.Mappers.WriterMappers;

public class ReadWriterMapper : IVmMapper<Writer, ReadWriterViewModel>
{
    public ReadWriterViewModel Map(Writer source)
    {
        var vm = new ReadWriterViewModel()
        {
            Description = source.Description,
            FullName = source.FullName,
            Id = source.Id,
            Pictures = source.Pictures.Select(p => p.FullPath)
        };
        return vm;
    }
}