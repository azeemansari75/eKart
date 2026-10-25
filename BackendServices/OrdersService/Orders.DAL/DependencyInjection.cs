using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Orders.DAL;

public static class DependencyInjection
{
    public static IServiceCollection AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
    {
        //string connectionString = configuration.GetConnectionString("DbConnection")!;


        //services.AddScoped<IProductRepository, ProductRepository>();

        return services;
    }
}
