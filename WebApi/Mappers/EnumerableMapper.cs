using Core.Interfaces.Mappers;

namespace WebApi.Mappers;

public class EnumerableMapper<TSource, TDest> : IEnumerableVmMapper<TSource, TDest>
{
    private readonly IVmMapper<TSource, TDest> _mapper;
    public EnumerableMapper(IVmMapper<TSource, TDest> mapper)
    {
        _mapper = mapper;
    }
    
    public IEnumerable<TDest> Map(IEnumerable<TSource> source)
    {
        var result = new List<TDest>();
        foreach (var element in source)
        {
            var mappedElement = _mapper.Map(element);
            result.Add(mappedElement);
        }

        return result;
    }
}