using EmployeesSection.Application.Infrastructure.Services.Dto;

namespace EmployeesSection.Application.Infrastructure.Services;

public interface ICrudAppService<TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, TGetInput, TDeleteInput> 
    : IApplicationService
    where TEntityDto : IEntityDto<TPrimaryKey>
    where TUpdateInput : IEntityDto<TPrimaryKey>
    where TDeleteInput : IEntityDto<TPrimaryKey>
    where TGetInput : IEntityDto<TPrimaryKey>
{
    TEntityDto Get(TGetInput input);
    PagedResultDto<TEntityDto> GetAll(TGetAllInput input);
    TEntityDto Create(TCreateInput input);
    TEntityDto Update(TUpdateInput input);
    void Delete(TDeleteInput input);
}

public interface ICrudAppService<TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, TGetInput> 
    : ICrudAppService<TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, TGetInput, EntityDto<TPrimaryKey>>
    where TEntityDto : IEntityDto<TPrimaryKey>
    where TUpdateInput : IEntityDto<TPrimaryKey>
    where TGetInput : IEntityDto<TPrimaryKey>
{ }

public interface ICrudAppService<TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput> 
    : ICrudAppService<TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, EntityDto<TPrimaryKey>>
    where TEntityDto : IEntityDto<TPrimaryKey>
    where TUpdateInput : IEntityDto<TPrimaryKey>
{ }

public interface ICrudAppService<TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput> 
    : ICrudAppService<TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TCreateInput>
    where TEntityDto : IEntityDto<TPrimaryKey>
    where TCreateInput : IEntityDto<TPrimaryKey>
{ }

public interface ICrudAppService<TEntityDto, TPrimaryKey, TGetAllInput> 
    : ICrudAppService<TEntityDto, TPrimaryKey, TGetAllInput, TEntityDto>
    where TEntityDto : IEntityDto<TPrimaryKey>
{ }

public interface ICrudAppService<TEntityDto, TPrimaryKey> 
    : ICrudAppService<TEntityDto, TPrimaryKey, PagedAndSortedResultRequestDto, TEntityDto>
    where TEntityDto : IEntityDto<TPrimaryKey>
{ }

public interface ICrudAppService<TEntityDto> 
    : ICrudAppService<TEntityDto, int>
    where TEntityDto : IEntityDto<int>
{ }