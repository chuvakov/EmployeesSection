using EmployeesSection.Domain.Exceptions;
using EmployeesSection.Domain.Infrastructure.Entities;
using EmployeesSection.Domain.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EmployeesSection.Infrastructure.EntityFrameworkCore.Repositories;

public class EfCoreRepositoryBase<TDbContext, TEntity, TPrimaryKey> : RepositoryBase<TEntity, TPrimaryKey> 
where TEntity : class, IEntity<TPrimaryKey> 
where TDbContext : DbContext
{
    protected TDbContext Context { get; }
    protected DbSet<TEntity> Table { get; }

    public EfCoreRepositoryBase(TDbContext context)
    {
        Context = context;
        Table = Context.Set<TEntity>();
    }

    public override IQueryable<TEntity> GetAll() => Table;

    public override TEntity Get(TPrimaryKey id)
    {
        var entity = Table.FirstOrDefault(e => e.Id.Equals(id));

        if (entity == null)
        {
            throw new EntityNotFoundException(id, typeof(TEntity));
        }

        return entity;
    }

    public override TEntity Insert(TEntity entity)
    {
        var result = Table.Add(entity).Entity;
        Context.SaveChanges();
        return result;
    }

    public override void Update(TEntity entity)
    {
        Table.Update(entity);
        Context.SaveChanges();
    }

    public override void Delete(TPrimaryKey id)
    {
        var entity = Table.FirstOrDefault(e => e.Id.Equals(id));
        if (entity != null)
        {
            Delete(entity);
        }
    }

    public override void Delete(TEntity entity)
    {
        Table.Remove(entity);
        Context.SaveChanges();
    }
}