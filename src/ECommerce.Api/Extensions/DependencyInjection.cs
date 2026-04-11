using ECommerce.Application.Behaviors;
using ECommerce.Application.Commands.Users;
using FluentValidation;

namespace ECommerce.Api.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddProjectDependencies(this IServiceCollection services)
    {
        var applicationAssembly = typeof(CreateUserCommand).Assembly;

        // MediatR
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(applicationAssembly);
            config.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        // FluentValidation
        services.AddValidatorsFromAssembly(applicationAssembly);

        return services;
    }
}
