using Microsoft.EntityFrameworkCore;

namespace Core.Pagination;

public static class IQueryableExtensions
{
    public static async Task<PagedList<T>> ToPagedListAsync<T>(this IQueryable<T> source, int pageNumber = 1, int pageSize = 25)
    {
        var count = source.Count();
        var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        return new PagedList<T>(items, count, pageNumber, pageSize);
    }

    public static PagedList<T> ToPagedList<T>(this IList<T> source, int pageNumber = 1,
        int pageSize = 25)
    {
        var count = source.Count();
        var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        return new PagedList<T>(items, count, pageNumber, pageSize);
    }
}