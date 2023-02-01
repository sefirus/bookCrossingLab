using System.Linq.Expressions;
using Core.Interfaces;
using Core.Interfaces.Repositories;
using Core.Pagination;
using Core.Pagination.Parameters;
using Microsoft.EntityFrameworkCore.Query;

namespace Application.Services;

public class RepositoryDecorator<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected IRepository<TEntity> Wrappee;

    public RepositoryDecorator(IRepository<TEntity> wrappee)
    {
        Wrappee = wrappee;
    }

    public Task<PagedList<TEntity>> GetPaged(
        ParametersBase parameters, 
        Expression<Func<TEntity, bool>>? filter = null, 
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, 
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
    {
        var x = new RepositoryDecorator<TEntity>(Wrappee);
        return Wrappee.GetPaged(parameters, filter, orderBy, include);
    }

    public IQueryable<TEntity> GetQuery(
        Expression<Func<TEntity, bool>>? filter = null, 
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, 
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, 
        int? take = null,
        int? skip = null, 
        bool asNoTracking = false)
    { 
        return Wrappee.GetQuery(filter, orderBy, include, take, skip, asNoTracking);
    }

    public Task<IList<TEntity>> QueryAsync(
        Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, 
        int? take = null,
        int? skip = null, 
        bool asNoTracking = false)
    {
        return Wrappee.QueryAsync(filter, orderBy, include, take, skip, asNoTracking);
    }

    public Task<TEntity?> GetFirstOrDefaultAsync(
        Expression<Func<TEntity, bool>>? filter = null, 
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, 
        bool asNoTracking = false)
    {
        return Wrappee.GetFirstOrDefaultAsync(filter, include, asNoTracking);
    }

    public Task<TEntity> GetFirstOrThrowAsync(
        Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        bool asNoTracking = false)
    {
        return Wrappee.GetFirstOrThrowAsync(filter, include, asNoTracking);
    }

    public void Delete(TEntity entity)
    {
        Wrappee.Delete(entity);
    }

    public void Update(TEntity entity)
    {
        Wrappee.Update(entity);
    }

    public Task InsertAsync(TEntity entity)
    {
        if (entity is ICreatableEntity creatableEntity)
        {
            creatableEntity.CreatedDate = DateTime.UtcNow;
        }
        return Wrappee.InsertAsync(entity);
    }

    public Task SaveChangesAsync()
    {
        return Wrappee.SaveChangesAsync();
    }
}