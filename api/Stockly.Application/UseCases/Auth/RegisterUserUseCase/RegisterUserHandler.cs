using Stockly.Application.Exceptions;
using Stockly.Core.Entities;
using Stockly.Core.Repositories;
using Stockly.Core.Services;

namespace Stockly.Application.UseCases.Auth.RegisterUserUseCase;

public static class RegisterUserHandler
{
    public static async Task Handle(
        RegisterUserCommand command,
        IUserRepository userRepository,
        IHashService hashService)
    {
        var user = await userRepository.GetUserByEmailAsync(command.Email);

        if (user is not null)
            throw new AlreadyExistsException("User already exists");

        var passwordHash = hashService.HashPassword(command.Password);

        var newUser = new User(
            command.Name,
            command.Email,
            passwordHash
        );

        await userRepository.CreateUserAsync(newUser);
    }
}
