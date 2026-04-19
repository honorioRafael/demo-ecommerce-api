using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<User> User => Set<User>();
    public DbSet<Address> Address => Set<Address>();
    public DbSet<Merchant> Merchant => Set<Merchant>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}