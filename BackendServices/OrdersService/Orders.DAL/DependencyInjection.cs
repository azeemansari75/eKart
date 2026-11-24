using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Orders.DAL.Context;
using Orders.DAL.Repositories;
using Orders.DAL.RepositoryContracts;

namespace Orders.DAL;

public static class DependencyInjection
{
    public static IServiceCollection AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("DbConnection")!;
        services.AddDbContext<ApplicationDbContext>(opt =>
        {
            opt.UseSqlServer(connectionString);
        });


        services.AddScoped<IOrderRepository, OrderRepository>();

        return services;
    }
}
