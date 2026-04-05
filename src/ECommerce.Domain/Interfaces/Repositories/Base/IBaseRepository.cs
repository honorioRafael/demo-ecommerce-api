namespace ECommerce.Domain.Interfaces.Repositories.Base;

public interface IBaseRepository
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}