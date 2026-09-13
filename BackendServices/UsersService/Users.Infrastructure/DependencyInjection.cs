using Microsoft.Extensions.DependencyInjection;
using Users.Core.Repositories;
using Users.Infrastructure.DbContext;
using Users.Infrastructure.Implementations;

namespace Users.Infrastructure;

//Extension method
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {

        //Register Dapper DB Context
        services.AddTransient<DapperDbContext>();

        //Register UserRepository
        services.AddSingleton<IUserRepository, UserRepository>();

        return services;
    }
}
