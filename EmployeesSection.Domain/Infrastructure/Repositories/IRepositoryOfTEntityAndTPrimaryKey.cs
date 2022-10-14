using EmployeesSection.Domain.Infrastructure.Entities;

namespace EmployeesSection.Domain.Infrastructure.Repositories;

public interface IRepository<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
{
    IQueryable<TEntity> GetAll();
    TEntity Get(TPrimaryKey id);
    TEntity Insert(TEntity entity);
    void Update(TEntity entity);
    void Delete(TPrimaryKey id);
    void Delete(TEntity entity);
}