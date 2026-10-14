using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Users.Core.ServiceContracts;
using Users.Core.Services;
using Users.Core.Validators;

namespace Users.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        // Register business service
        services.AddTransient<IUsersService, UsersService>();

        // Register AutoMapper from this assembly
        services.AddAutoMapper(typeof(DependencyInjection).Assembly);

        // Register Validators
        services.AddValidatorsFromAssemblyContaining<LoginDtoValidator>();

        return services;

    }
}