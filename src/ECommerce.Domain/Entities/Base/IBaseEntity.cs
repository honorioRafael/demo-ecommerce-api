namespace ECommerce.Domain.Entities.Base;

public interface IBaseEntity
{
    Guid Id { get; }
    DateTime CreatedAt { get; }
    Guid CreatedBy { get; }
    DateTime? UpdatedAt { get; }
    Guid? UpdatedBy { get; }
}