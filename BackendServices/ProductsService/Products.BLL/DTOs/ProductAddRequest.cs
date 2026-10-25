namespace Products.BLL.DTOs;

public record ProductAddRequest(string ProductName, CategoryOptions Category, decimal? UnitPrice, int? QuantityInStock)
{
    public ProductAddRequest() : this(default, default, default, default)
    {
    }
}

