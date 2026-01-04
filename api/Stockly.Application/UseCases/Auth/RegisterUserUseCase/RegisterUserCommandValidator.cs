using FluentValidation;

namespace Stockly.Application.UseCases.Auth.RegisterUserUseCase;

public sealed class RegisterUserCommandValidator
    : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Email).EmailAddress();
        RuleFor(x => x.PasswordHash).MinimumLength(6);
    }
}
