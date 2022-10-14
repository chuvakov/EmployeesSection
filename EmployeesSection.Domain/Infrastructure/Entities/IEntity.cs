namespace EmployeesSection.Domain.Infrastructure.Entities;

public interface IEntity<TPrimaryKey>
{
    TPrimaryKey Id { get; set; }
}

public interface IEntity : IEntity<int>
{ }