using FluentValidation;

namespace Stockly.Application.UseCases.Auth.AuthenticateUserUseCase;

public sealed class AuthenticateUserCommandValidartor : AbstractValidator<AuthenticateUserCommand>
{
    public AuthenticateUserCommandValidartor()
    {
        RuleFor(x => x.Email)
           .NotEmpty().WithMessage("Email is required")
           .EmailAddress().WithMessage("Email is invalid");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters long");
    }
}