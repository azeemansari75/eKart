using FluentValidation;
using FluentValidation.Validators;
using Users.Core.DTOs;

namespace Users.Core.Validators;

public class RegisterDtoValidator : AbstractValidator<RegisterRequest>
{
    public RegisterDtoValidator()
    {
        RuleFor(rr => rr.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid Email");

        RuleFor(rr => rr.Password).NotEmpty().WithMessage("Password is required");

        RuleFor(rr => rr.PersonName).NotEmpty().WithMessage("person name is required");

        RuleFor(rr => rr.Gender).NotEmpty().WithMessage("Gender must enter");
    }
}

