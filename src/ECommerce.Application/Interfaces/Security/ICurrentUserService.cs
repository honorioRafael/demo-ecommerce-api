namespace ECommerce.Application.Interfaces.Security;

public interface ICurrentUserService
{
    Guid? UserId { get; }
}
