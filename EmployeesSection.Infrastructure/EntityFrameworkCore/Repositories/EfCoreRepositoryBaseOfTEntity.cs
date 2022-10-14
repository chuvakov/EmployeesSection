using EmployeesSection.Domain.Infrastructure.Entities;
using EmployeesSection.Domain.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EmployeesSection.Infrastructure.EntityFrameworkCore.Repositories;

public class EfCoreRepositoryBase<TDbContext, TEntity> 
    : EfCoreRepositoryBase<TDbContext, TEntity, int>, IRepository<TEntity>
    where TEntity : class, IEntity<int>
    where TDbContext : DbContext
{
    protected EfCoreRepositoryBase(TDbContext context) : base(context)
    {
    }
}