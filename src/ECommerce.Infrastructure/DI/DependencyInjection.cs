using ECommerce.Application.Interfaces.Jwt;
using ECommerce.Application.Interfaces.Security;
using ECommerce.Infrastructure.Authentication;
using ECommerce.Infrastructure.Persistence.Contexts;
using ECommerce.Infrastructure.Persistence.Interceptors;
using ECommerce.Infrastructure.Persistence.Repositories;
using ECommerce.Infrastructure.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ECommerce.Infrastructure.DI;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<AuditableEntityInterceptor>();

        services.AddSingleton<IPasswordHasher, BCryptPasswordHasher>();

        #region Database
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        #endregion

        #region Authentication
        services.AddOptions<JwtSettings>()
            .Bind(configuration.GetSection(JwtSettings.SectionName))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        services.AddSingleton<IJwtProvider, JwtProvider>();

        var jwtSettings = configuration.GetSection(JwtSettings.SectionName).Get<JwtSettings>();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings!.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtSettings.Secret))
                };
            });

        services.AddAuthorization();
        #endregion

        #region Repository DI
        services.Scan(scan => scan
            .FromAssembliesOf(typeof(AppDbContext))
            .AddClasses(classes => classes.InNamespaces(typeof(UserRepository).Namespace!))
            .AsImplementedInterfaces()
            .WithScopedLifetime());
        #endregion

        return services;
    }
}