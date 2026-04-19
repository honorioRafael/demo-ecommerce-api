using ECommerce.Application.Interfaces.Security;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ECommerce.Infrastructure.Persistence.Interceptors;

public class AuditableEntityInterceptor : SaveChangesInterceptor
{
    private readonly ICurrentUserService _currentUserService;

    public AuditableEntityInterceptor(ICurrentUserService currentUserService)
    {
        _currentUserService = currentUserService;
    }

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        UpdateEntities(eventData.Context);
        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        UpdateEntities(eventData.Context);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private void UpdateEntities(DbContext? context)
    {
        if (context == null) return;

        var currentUserId = _currentUserService.UserId;

        foreach (var entry in context.ChangeTracker.Entries<BaseEntity>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Property(x => x.CreatedAt).CurrentValue = DateTime.UtcNow;

                if (currentUserId.HasValue)
                {
                    entry.Property(x => x.CreatedBy).CurrentValue = currentUserId.Value;
                }
                else
                {
                    entry.Property(x => x.CreatedBy).CurrentValue = entry.Entity is User ? entry.Entity.Id : Guid.Empty;
                }
            }
            else if (entry.State == EntityState.Modified)
            {
                entry.Property(x => x.UpdatedAt).CurrentValue = DateTime.UtcNow;

                if (currentUserId.HasValue)
                {
                    entry.Property(x => x.UpdatedBy).CurrentValue = currentUserId.Value;
                }
            }
        }
    }
}