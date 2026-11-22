using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Orders.BLL;

public static class DependencyInjection
{
    public static IServiceCollection AddBusinessLogicLayer(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddAutoMapper(typeof(ProductAddRequestToProductMappingProfile).Assembly);
        //services.AddScoped<IProductService, ProductService>();
        //services.AddValidatorsFromAssemblyContaining<ProductAddRequestValidator>();

        return services;
    }
}
