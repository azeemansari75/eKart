namespace Products.BLL.DTOs;

public record ProductUpdateRequest(Guid ProductId, string ProductName, CategoryOptions Category, decimal? UnitPrice, int? QuantityInStock)
{
    public ProductUpdateRequest() : this(default, default, default, default,default)
    {
    }
}

