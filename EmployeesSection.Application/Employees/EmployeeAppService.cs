using AutoMapper;
using EmployeesSection.Application.Employees.Dto;
using EmployeesSection.Application.Infrastructure.Services;
using EmployeesSection.Domain.Employees;
using EmployeesSection.Domain.Infrastructure.Repositories;

namespace EmployeesSection.Application.Employees;

public class EmployeeAppService : CrudAppServiceBase<Employee, EmployeeDto>, IEmployeeAppService
{
    public EmployeeAppService(IRepository<Employee, int> repository, IMapper mapper) : base(repository, mapper)
    {
    }
}