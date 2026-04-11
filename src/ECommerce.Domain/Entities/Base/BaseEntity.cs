namespace ECommerce.Domain.Entities.Base;

public abstract class BaseEntity
{
    public Guid Id { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public Guid CreatedBy { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public Guid? UpdatedBy { get; private set; }

    protected BaseEntity()
    {
        Id = Guid.NewGuid();
    }
}