using FluentValidation;
using Products.BLL.DTOs;

namespace Products.BLL.Validators;

public class ProductAddRequestValidator : AbstractValidator<ProductAddRequest>
{
    public ProductAddRequestValidator()
    {
        RuleFor(req => req.ProductName)
            .NotEmpty().WithMessage("Product Name can't be blank.");

        RuleFor(req => req.Category)
            .IsInEnum().WithMessage("Invalid Category");

        RuleFor(x => x.UnitPrice)
              .InclusiveBetween(0m, 100000m)
              .WithMessage("Unit price must be between 0 and 100000");

        RuleFor(req => req.QuantityInStock)
            .InclusiveBetween(1, int.MaxValue).WithMessage($"QuantityInStock must be between 1 and {int.MaxValue}.");
    }
}
