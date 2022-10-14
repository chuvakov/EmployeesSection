namespace EmployeesSection.Application.Infrastructure.Services.Dto;

public class PagedResultDto<TEntityDto> 
{
    public int TotalCount { get; set; }
    public IEnumerable<TEntityDto> Items { get; set; }
    
    public PagedResultDto(int totalCount, IEnumerable<TEntityDto> items)
    {
        TotalCount = totalCount;
        Items = items;
    }
}