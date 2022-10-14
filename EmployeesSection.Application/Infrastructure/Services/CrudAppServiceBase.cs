using AutoMapper;
using EmployeesSection.Application.Infrastructure.Services.Dto;
using EmployeesSection.Domain.Infrastructure.Entities;
using EmployeesSection.Domain.Infrastructure.Repositories;
using System.Linq.Dynamic.Core;

namespace EmployeesSection.Application.Infrastructure.Services;

public abstract class CrudAppServiceBase<TEntity, TEntityDto>
    : CrudAppServiceBase<TEntity, TEntityDto, int>
    where TEntity : class, IEntity<int>
    where TEntityDto : IEntityDto<int>
{
    protected CrudAppServiceBase(IRepository<TEntity, int> repository, IMapper mapper) : base(repository, mapper)
    {
    }
}

public abstract class CrudAppServiceBase<TEntity, TEntityDto, TPrimaryKey>
    : CrudAppServiceBase<TEntity, TEntityDto, TPrimaryKey, PagedAndSortedResultRequestDto>
    where TEntity : class, IEntity<TPrimaryKey>
    where TEntityDto : IEntityDto<TPrimaryKey>
{
    protected CrudAppServiceBase(IRepository<TEntity, TPrimaryKey> repository, IMapper mapper) : base(repository, mapper)
    {
    }
}

public abstract class CrudAppServiceBase<TEntity, TEntityDto, TPrimaryKey, TGetAllInput>
    : CrudAppServiceBase<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TEntityDto>
    where TEntity : class, IEntity<TPrimaryKey>
    where TEntityDto : IEntityDto<TPrimaryKey>
{
    protected CrudAppServiceBase(IRepository<TEntity, TPrimaryKey> repository, IMapper mapper) : base(repository, mapper)
    {
    }
}

public abstract class CrudAppServiceBase<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput>
    : CrudAppServiceBase<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TCreateInput>
    where TEntity : class, IEntity<TPrimaryKey>
    where TEntityDto : IEntityDto<TPrimaryKey>
    where TCreateInput : IEntityDto<TPrimaryKey>
{
    protected CrudAppServiceBase(IRepository<TEntity, TPrimaryKey> repository, IMapper mapper) : base(repository, mapper)
    {
    }
}

public abstract class CrudAppServiceBase<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput>
    : CrudAppServiceBase<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, EntityDto<TPrimaryKey>>
    where TEntity : class, IEntity<TPrimaryKey>
    where TEntityDto : IEntityDto<TPrimaryKey>
    where TUpdateInput : IEntityDto<TPrimaryKey>
{
    protected CrudAppServiceBase(IRepository<TEntity, TPrimaryKey> repository, IMapper mapper) : base(repository, mapper)
    {
    }
}

public abstract class CrudAppServiceBase<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput,
        TGetInput>
    : CrudAppServiceBase<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, TGetInput,
        EntityDto<TPrimaryKey>>
    where TEntity : class, IEntity<TPrimaryKey>
    where TEntityDto : IEntityDto<TPrimaryKey>
    where TUpdateInput : IEntityDto<TPrimaryKey>
    where TGetInput : IEntityDto<TPrimaryKey>
{
    protected CrudAppServiceBase(IRepository<TEntity, TPrimaryKey> repository, IMapper mapper) : base(repository, mapper)
    {
    }
}

public abstract class CrudAppServiceBase<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, TGetInput, TDeleteInput>
    : ICrudAppService<TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, TGetInput, TDeleteInput>
    where TEntity : class, IEntity<TPrimaryKey>
    where TEntityDto : IEntityDto<TPrimaryKey>
    where TUpdateInput : IEntityDto<TPrimaryKey>
    where TGetInput : IEntityDto<TPrimaryKey>
    where TDeleteInput : IEntityDto<TPrimaryKey>
{
    protected readonly IRepository<TEntity, TPrimaryKey> Repository;
    protected readonly IMapper Mapper;

    protected CrudAppServiceBase(IRepository<TEntity, TPrimaryKey> repository, IMapper mapper)
    {
        Repository = repository;
        Mapper = mapper;
    }

    public TEntityDto Get(TGetInput input)
    {
        var entity = Repository.Get(input.Id);
        return Mapper.Map<TEntityDto>(entity);
    }

    public PagedResultDto<TEntityDto> GetAll(TGetAllInput input)
    {
        var query = Repository.GetAll();
        var totalCount = query.Count();

        if (input is PagedAndSortedResultRequestDto sortInput && sortInput.Sorting != null)
        {
            query = query.OrderBy(sortInput.Sorting);
        }
        
        if (input is PagedResultRequestDto pagedInput)
        {
            if (pagedInput.SkipCount.HasValue)
            {
                query = query.Skip(pagedInput.SkipCount.Value);
            }

            if (pagedInput.MaxResultCount.HasValue)
            {
                query = query.Take(pagedInput.MaxResultCount.Value);
            }
        }

        var entities = query.ToList();
        return new PagedResultDto<TEntityDto>(totalCount, Mapper.Map<IEnumerable<TEntityDto>>(entities));
    }

    public TEntityDto Create(TCreateInput input)
    {
        var entity = Mapper.Map<TEntity>(input);
        Repository.Insert(entity);
        return Mapper.Map<TEntityDto>(entity);
    }

    public TEntityDto Update(TUpdateInput input)
    {
        var entity = Repository.Get(input.Id);
        
        Mapper.Map(input, entity);
        Repository.Update(entity);
        
        return Mapper.Map<TEntityDto>(entity);
    }

    public void Delete(TDeleteInput input)
    {
        Repository.Delete(input.Id);
    }
}

