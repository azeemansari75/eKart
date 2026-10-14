using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Products.BLL.DTOs;
using Products.BLL.ServiceContracts;
using Products.DAL.Entities;
using Products.DAL.RepositoriesContracts;
using System.Linq.Expressions;

namespace Products.BLL.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<ProductAddRequest> _productAddRrequestValidator;
    private readonly IValidator<ProductUpdateRequest> _productUpdateRrequestValidator;

    public ProductService(IProductRepository productRepository, IMapper mapper, 
        IValidator<ProductAddRequest> productAddRequestValidator, 
        IValidator<ProductUpdateRequest> productUpdateRequestValidator)
    {
        _productRepository = productRepository;
        _mapper = mapper;
        _productAddRrequestValidator = productAddRequestValidator;
        _productUpdateRrequestValidator = productUpdateRequestValidator;
    }
    
    public async Task<ProductResponse?> AddProduct(ProductAddRequest productAddRequest)
    {
        if(productAddRequest == null)
        {
            throw new ArgumentNullException("Product Add Request is null.");
        }

        ValidationResult validationResults = await _productAddRrequestValidator.ValidateAsync(productAddRequest);
        if (!validationResults.IsValid)
        {
            IEnumerable<string> errorMessages = validationResults.Errors.Select(vf => vf.ErrorMessage);
            string errorMessage = string.Join(", ", errorMessages); // error 1, error 2, error 3.....
        }

        Product? addedProduct =  await _productRepository.AddProduct(_mapper.Map<Product>(productAddRequest));
        if(addedProduct == null)
        {
            throw new ArgumentNullException("Product Not Added");
        }

        return _mapper.Map<ProductResponse?>(addedProduct);
    } 

    public async Task<ProductResponse?> UpdateProduct(ProductUpdateRequest productUpdateRequest)
    {
        if(productUpdateRequest == null)
        {
            throw new ArgumentNullException("Product Update Request is null.");
        }

        ValidationResult validationResults = await _productUpdateRrequestValidator.ValidateAsync(productUpdateRequest);
        if (!validationResults.IsValid)
        {
            IEnumerable<string> errorMessages = validationResults.Errors.Select(vf => vf.ErrorMessage);
            string errorMessage = string.Join(", ", errorMessages); // error 1, error 2, error 3.....

            throw new ArgumentException(errorMessage);
        }

        Product? product =  _mapper.Map<Product>(productUpdateRequest);

        Product? updatedProduct =  await _productRepository.UpdateProduct(product);
        if(updatedProduct == null)
        {
            return null;
        }

        return _mapper.Map<ProductResponse>(updatedProduct);
    }   

    public async Task<bool> DeleteProduct(Guid productID)
    {
        if(productID == Guid.Empty)
        {
            throw new ArgumentNullException("Product Not Found");
        }

        Product? existingProduct = await _productRepository.GetProductByCondition(p => p.ProductID == productID);
        if(existingProduct != null)
        {
            throw new ArgumentNullException("Product Not Found");
        }

        bool isDeleted = await _productRepository.DeleteProduct(productID);

        return isDeleted;
    }

    public async Task<ProductResponse?> GetProductByCondition(Expression<Func<Product, bool>> conditionExpression)
    {
        Product? product = await _productRepository.GetProductByCondition(conditionExpression);
        if (product == null)
        {
            throw new ArgumentNullException("Product not found.");
        }
        return _mapper.Map<ProductResponse?>(product);
    }

    public async Task<List<ProductResponse?>> GetProducts()
    {
        IEnumerable<Product> products = await _productRepository.GetProducts();
        if(products == null || !products.Any())
        {
            throw new ArgumentNullException("No products found.");
        }

        return _mapper.Map<List<ProductResponse?>>(products);
    }

    public async Task<List<ProductResponse?>> GetProductsByCondition(Expression<Func<Product, bool>> conditionExpression)
    {
        IEnumerable<Product> products = await _productRepository.GetProductsByCondition(conditionExpression);
        if(products == null || !products.Any())
        {
            throw new ArgumentNullException("No products found.");
        }

        return _mapper.Map<List<ProductResponse?>>(products);
    }

}
