using AutoMapper;
using EmployeesSection.Application.Infrastructure.Services.Dto;
using EmployeesSection.Domain.Employees;

namespace EmployeesSection.Application.Employees.Dto;

[AutoMap(typeof(Employee), ReverseMap = true)]
public class EmployeeDto : EntityDto
{
    public EmployeeDto(int id, string name, string surname, string patronymic, string position) : base(id)
    {
        Name = name;
        Surname = surname;
        Patronymic = patronymic;
        Position = position;
    }

    public string Name { get; set; }
    public string Surname { get; set; }
    public string Patronymic { get; set; }
    public string Position { get; set; }
}