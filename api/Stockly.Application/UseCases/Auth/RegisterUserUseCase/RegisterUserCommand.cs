namespace Stockly.Application.UseCases.Auth.RegisterUserUseCase;

public record RegisterUserCommand
{
    public required string Name { get; init; }
    public required string Email { get; init; }
    public required string PasswordHash { get; init; }
}