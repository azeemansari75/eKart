using Products.BLL.DTOs;
using Products.DAL.Entities;
using System.Linq.Expressions;

namespace Products.BLL.ServiceContracts;

public interface IProductService
{
    Task<List<ProductResponse?>> GetProducts();
    Task<List<ProductResponse?>> GetProductsByCondition(Expression<Func<Product, bool>> conditionExpression);
    Task<ProductResponse?> GetProductByCondition(Expression<Func<Product, bool>> conditionExpression);
    Task<ProductResponse?> AddProduct(ProductAddRequest productAddRequest);
    Task<ProductResponse?> UpdateProduct(ProductUpdateRequest productUpdateRequest);
    Task<bool> DeleteProduct(Guid productID);
}
