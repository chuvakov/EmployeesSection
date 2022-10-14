using EmployeesSection.Domain.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeesSection.Domain.Employees;

[Index(nameof(Surname), nameof(Name), nameof(Patronymic), IsUnique = true)]
public class Employee : Entity
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Patronymic { get; set; }
    public string Position { get; set; }
}