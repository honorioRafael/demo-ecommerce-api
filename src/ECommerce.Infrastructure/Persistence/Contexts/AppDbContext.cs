using ECommerce.Domain.Entities.Base;
using ECommerce.Infrastructure.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Persistence.Contexts;

public class AppDbContext : DbContext
{
    private readonly AuditableEntityInterceptor _auditableEntityInterceptor;

    public AppDbContext(DbContextOptions<AppDbContext> options, AuditableEntityInterceptor auditableEntityInterceptor) : base(options)
    {
        _auditableEntityInterceptor = auditableEntityInterceptor;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_auditableEntityInterceptor);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var entityTypes = typeof(BaseEntity).Assembly.GetTypes().Where(t => typeof(BaseEntity).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);
        foreach (var type in entityTypes)
        {
            modelBuilder.Entity(type);
        }

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
