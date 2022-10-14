using EmployeesSection.Domain.Employees;
using Microsoft.EntityFrameworkCore;

namespace EmployeesSection.Infrastructure.EntityFrameworkCore;

public class EmployeesSectionContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }

    public EmployeesSectionContext(DbContextOptions options) : base(options)
    {
        // Database.EnsureCreated();
    }
    
    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<Employee>().HasData(
    //         new Employee { Id = 1, Name = "Иван", Surname = "Иванов", Patronymic = "Иванович", Position = "manager" },
    //         new Employee { Id = 1, Name = "Петр", Surname = "Петров", Patronymic = "Петрович", Position = "manager" },
    //         new Employee { Id = 1, Name = "Сергей", Surname = "Сергеев", Patronymic = "Сергеевич", Position = "manager" }
    //     );
    // }
}