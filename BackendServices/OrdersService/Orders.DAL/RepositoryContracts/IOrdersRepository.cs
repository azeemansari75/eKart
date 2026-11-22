using Orders.DAL.Entities;
using System.Linq.Expressions;

namespace Orders.DAL.RepositoryContracts;

public interface IOrderRepository
{
    Task<Order?> AddOrder(Order order);

    Task<bool> DeleteOrder(Guid orderID);

    Task<Order?> GetOrderByCondition(Expression<Func<Order, bool>> condition);

    Task<IEnumerable<Order>> GetOrders();

    Task<IEnumerable<Order>> GetOrdersByCondition(Expression<Func<Order, bool>> condition);

    Task<Order?> UpdateOrder(Order order);
}
