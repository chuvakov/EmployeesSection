using EmployeesSection.Domain.Infrastructure.Entities;

namespace EmployeesSection.Domain.Infrastructure.Repositories;

public abstract class RepositoryBase<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey> 
    where TEntity : class, IEntity<TPrimaryKey>
{
    public abstract IQueryable<TEntity> GetAll();
    public abstract TEntity Get(TPrimaryKey id);
    public abstract TEntity Insert(TEntity entity);
    public abstract void Update(TEntity entity);
    public abstract void Delete(TPrimaryKey id);
    public abstract void Delete(TEntity entity);
}

public abstract class RepositoryBase<TEntity> : RepositoryBase<TEntity, int> 
    where TEntity : class, IEntity<int>
{ }