using ECommerce.Domain.Interfaces.Repositories;
using ECommerce.Infrastructure.Persistence.Contexts;

namespace ECommerce.Infrastructure.Persistence.Repositories;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await context.SaveChangesAsync(cancellationToken);
    }
}
