namespace EmployeesSection.Application.Infrastructure.Services.Dto;

public class PagedAndSortedResultRequestDto : PagedResultRequestDto
{
    /// <summary>
    /// Формат сортировки: propertyName asc/desc
    /// </summary>
    public virtual string Sorting { get; set; }
}