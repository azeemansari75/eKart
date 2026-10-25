namespace Products.BLL.DTOs;

public record ProductResponse(Guid ProductID, string ProductName, CategoryOptions Category, decimal? UnitPrice, int? QuantityInStock)
{
    public ProductResponse() : this(default, default, default, default, default)
    {
    }
}

