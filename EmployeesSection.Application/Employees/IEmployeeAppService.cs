using EmployeesSection.Application.Employees.Dto;
using EmployeesSection.Application.Infrastructure.Services;

namespace EmployeesSection.Application.Employees;

public interface IEmployeeAppService : ICrudAppService<EmployeeDto>
{
    
}