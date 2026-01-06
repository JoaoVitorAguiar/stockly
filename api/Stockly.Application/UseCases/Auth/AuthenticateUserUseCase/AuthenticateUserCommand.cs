namespace Stockly.Application.UseCases.Auth.AuthenticateUserUseCase;

public record AuthenticateUserCommand
{
    public string Email { get; init; }
    public string Password { get; init; }
}