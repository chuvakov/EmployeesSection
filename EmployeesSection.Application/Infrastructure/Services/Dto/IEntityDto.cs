namespace EmployeesSection.Application.Infrastructure.Services.Dto;

public interface IEntityDto<TPrimaryKey>
{
    TPrimaryKey Id { get; set; }
}

public interface IEntityDto : IEntityDto<int>
{ }