using Stockly.Application.Exceptions;
using Stockly.Core.Repositories;
using Stockly.Core.Services;

namespace Stockly.Application.UseCases.Auth.AuthenticateUserUseCase;

public static class AuthenticateUserHandler
{
    public static async Task<string> Handle(
        AuthenticateUserCommand command,
        IUserRepository userRepository,
        IHashService hashService,
        ITokenService tokenService)
    {
        var user = await userRepository.GetUserByEmailAsync(command.Email)
            ?? throw new NotFoundException("User not found");

        var passwordsMatch = hashService.VerifyPassword(command.Password, user.PasswordHash);

        if (!passwordsMatch) throw new InvalidCredentialsException();

        var token = tokenService.GenerateToken(user);

        return token;
    }
}