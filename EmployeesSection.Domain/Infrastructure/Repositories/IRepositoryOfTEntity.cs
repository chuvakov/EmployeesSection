using EmployeesSection.Domain.Infrastructure.Entities;

namespace EmployeesSection.Domain.Infrastructure.Repositories;

public interface IRepository<TEntity> : 
    IRepository<TEntity, int> where TEntity : class, IEntity<int>
{ }