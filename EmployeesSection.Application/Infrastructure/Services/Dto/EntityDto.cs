namespace EmployeesSection.Application.Infrastructure.Services.Dto;

public class EntityDto<TPrimaryKey> : IEntityDto<TPrimaryKey>
{
    public TPrimaryKey Id { get; set; }

    public EntityDto(TPrimaryKey id)
    {
        Id = id;
    }
}

public class EntityDto : EntityDto<int>, IEntityDto
{
    public EntityDto(int id) : base(id)
    {
    }
}