using EmployeesSection.Application.Employees;
using EmployeesSection.Application.Employees.Dto;
using EmployeesSection.Application.Infrastructure.Services.Dto;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesSection.WebApi.Controllers;

public class EmployeesController : EmployeesSectionControllerBase
{
    private readonly IEmployeeAppService _employeeAppService;

    public EmployeesController(IEmployeeAppService employeeAppService)
    {
        _employeeAppService = employeeAppService;
    }

    [HttpPost("[action]")]
    public IActionResult GetAll(PagedAndSortedResultRequestDto input)
    {
        var employees = _employeeAppService.GetAll(input);
        return Ok(employees);
    }
    
    [HttpGet("[action]")]
    public IActionResult Get(int id)
    {
        var employee = _employeeAppService.Get(new EntityDto(id));
        return Ok(employee);
    }
    
    [HttpDelete("[action]")]
    public IActionResult Delete(int id)
    {
        _employeeAppService.Delete(new EntityDto(id));
        return Ok("success");
    }
    
    [HttpPost("[action]")]
    public IActionResult Update(EmployeeDto input)
    {
        var employee = _employeeAppService.Update(input);
        return Ok(employee);
    }
    
}