using FluentValidation;
using Users.Core.DTOs;

namespace Users.Core.Validators;

public class LoginDtoValidator : AbstractValidator<LoginRequest>
{
    public LoginDtoValidator()
    {
        RuleFor(lr => lr.Email).NotEmpty().WithMessage("Email Is Required");
        RuleFor(lr => lr.Email).EmailAddress().WithMessage("Invalid Email");

        RuleFor(lr => lr.Password).NotEmpty().WithMessage("Password Is Required");
    }
}
