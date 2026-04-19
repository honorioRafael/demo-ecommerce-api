using ECommerce.Domain.Entities;
using ECommerce.Infrastructure.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Persistence.Contexts;

public class AppDbContext : DbContext
{
    private readonly AuditableEntityInterceptor _auditableEntityInterceptor;

    public DbSet<User> User => Set<User>();
    public DbSet<Address> Address => Set<Address>();
    public DbSet<Merchant> Merchant => Set<Merchant>();

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
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}