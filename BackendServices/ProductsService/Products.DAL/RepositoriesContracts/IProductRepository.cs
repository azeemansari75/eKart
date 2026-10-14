using Products.DAL.Entities;
using System.Linq.Expressions;

namespace Products.DAL.RepositoriesContracts;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetProducts();
    Task<IEnumerable<Product?>> GetProductsByCondition(Expression<Func<Product, bool>> condtionExpression);
    Task<Product?> GetProductByCondition(Expression<Func<Product, bool>> condtionExpression);

    Task<Product?> AddProduct(Product product);
    Task<Product?> UpdateProduct(Product product);

    Task<bool> DeleteProduct(Guid productId);
}
