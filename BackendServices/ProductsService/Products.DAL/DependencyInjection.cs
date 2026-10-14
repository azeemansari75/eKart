using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Products.DAL.Context;
using Products.DAL.Repositories;
using Products.DAL.RepositoriesContracts;

namespace Products.DAL;

public static class DependencyInjection
{
    public static IServiceCollection AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("DefaultConnection")!;

        services.AddDbContext<ApplicationDbContext>(option =>
        {
            option.UseMySQL(connectionString);
        });

        services.AddScoped<IProductRepository, ProductRepository>();

        return services;
    }
}
