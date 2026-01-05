namespace Stockly.Application.UseCases.Auth.RegisterUserUseCase;

public record RegisterUserCommand
{
    public string Name { get; init; }
    public string Email { get; init; }
    public string Password { get; init; }
}