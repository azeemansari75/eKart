namespace Orders.BLL.DTOs;

public record OrderItemResponse(Guid ProductID, decimal UnitPrice, int Quantity, decimal TotalPrice)
{
    public OrderItemResponse() : this(default, default, default, default)
    {
    }
}
