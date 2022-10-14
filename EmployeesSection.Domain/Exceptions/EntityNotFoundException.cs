namespace EmployeesSection.Domain.Exceptions;

public class EntityNotFoundException : Exception
{
    public object Id { get; set; }
    public Type EntityType { get; set; }
    
    public EntityNotFoundException(object id, Type entityType) 
        : base($"Запись с Id {id} не найдена в таблице {entityType}")
    {
        Id = id;
        EntityType = entityType;
    }
}