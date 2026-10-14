using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Products.BLL.Mappers;
using Products.BLL.ServiceContracts;
using Products.BLL.Services;
using Products.BLL.Validators;

namespace Products.BLL;

public static class DependencyInjection
{
    public static IServiceCollection AddBusinessLogicLayer(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ProductAddRequestToProductMappingProfile).Assembly);
        services.AddScoped<IProductService, ProductService>();
        services.AddValidatorsFromAssemblyContaining<ProductAddRequestValidator>();

        return services;
    }
}