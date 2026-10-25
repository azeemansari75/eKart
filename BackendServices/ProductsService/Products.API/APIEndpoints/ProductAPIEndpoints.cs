using Products.BLL.DTOs;
using Products.BLL.ServiceContracts;

namespace Products.API.APIEndpoints;

public static class ProductAPIEndpoints
{
    public static IEndpointRouteBuilder MapProductAPIEndpoints(this IEndpointRouteBuilder app)
    {
        // Get all products
        app.MapGet("/api/products", async (IProductService productService) =>
        {
            return Results.Ok(await productService.GetProducts());
        });

        // Get product by ID
        app.MapGet("/api/products/search/product-id/{productID:guid}",
            async (IProductService productService, Guid productID) =>
            {
                ProductResponse? product = await productService.GetProductByCondition(p => p.ProductID == productID);

                return product is null ? Results.NotFound() : Results.Ok(product);
            });

        // Search by product name OR category
        // Search by product name OR category
        app.MapGet("/api/products/search/{searchString}",
            async (IProductService productService, string searchString) =>
            {
                var nameMatches = await productService.GetProductsByCondition(
            p => p.ProductName.Contains(searchString));

                var categoryMatches = await productService.GetProductsByCondition(
            p => p.Category != null && p.Category.Contains(searchString));

                var result = (nameMatches ?? new())
            .Concat(categoryMatches ?? new())
            .Where(p => p is not null)
            .DistinctBy(p => p!.ProductID)
            .ToList();

                return result.Count == 0 ? Results.NotFound() : Results.Ok(result);
            });
        // Add product
        app.MapPost("/api/products/addproduct",
            async (IProductService service, ProductAddRequest productAddRequest) =>
            {
                ProductResponse? addedProduct = await service.AddProduct(productAddRequest);

                return addedProduct is null
                    ? Results.Problem("Error while adding product")
                    : Results.Created($"/api/products/search/product-id/{addedProduct.ProductID}", addedProduct);
            });

        // Update product
        app.MapPut("/api/products/updateproduct",
            async (IProductService service, ProductUpdateRequest productUpdateRequest) =>
            {
                if (productUpdateRequest is null || productUpdateRequest.ProductId == Guid.Empty)
                {
                    return Results.BadRequest("Invalid product update request");
                }

                ProductResponse? updatedProduct = await service.UpdateProduct(productUpdateRequest);

                return updatedProduct is null
                    ? Results.Problem("Error while updating product")
                    : Results.Ok(updatedProduct);
            });

        // Delete product
        app.MapDelete("/api/products/deleteproduct/{productID:guid}",
            async (IProductService service, Guid productID) =>
            {
                if (productID == Guid.Empty)
                {
                    return Results.BadRequest("Invalid product ID");
                }

                bool isDeleted = await service.DeleteProduct(productID);

                return isDeleted
                    ? Results.Ok("Product deleted successfully.")
                    : Results.Problem("Error while deleting product");
            });

        return app;
    }
}