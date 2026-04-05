using ECommerce.Domain.Interfaces.Repositories;
using ECommerce.Infrastructure.Persistence.Contexts;
using ECommerce.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Infrastructure.DI;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services.Scan(scan => scan
            .FromAssembliesOf(typeof(AppDbContext))
            .AddClasses(classes => classes.InNamespaces(typeof(UserRepository).Namespace!))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        return services;
    }
}