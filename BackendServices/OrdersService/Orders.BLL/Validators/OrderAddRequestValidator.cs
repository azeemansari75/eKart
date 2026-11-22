using FluentValidation;
using Orders.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Orders.BLL.Validators;

public class OrderAddRequestValidator : AbstractValidator<OrderAddRequest>
{
    public OrderAddRequestValidator()
    {
        //UserID
        RuleFor(temp => temp.UserID)
          .NotEmpty().WithMessage("User ID can't be blank");

        //OrderDate
        RuleFor(temp => temp.OrderDate)
          .NotEmpty().WithMessage("Order Date can't be blank");

        //OrderItems
        RuleFor(temp => temp.OrderItems)
          .NotEmpty().WithMessage("Order Items can't be blank");
    }
}
