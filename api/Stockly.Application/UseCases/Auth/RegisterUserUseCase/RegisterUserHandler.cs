using Stockly.Application.Exceptions;
using Stockly.Core.Entities;
using Stockly.Core.Repositories;

namespace Stockly.Application.UseCases.Auth.RegisterUserUseCase;

public static class RegisterUserHandler
{
    public static async Task Handle(
        RegisterUserCommand command,
        IUserRepository userRepository)
    {
        var user = await userRepository.GetUserByEmailAsync(command.Email);

        if (user is not null)
            throw new AlreadyExistsException("User already exists");

        var newUser = new User(
            command.Name,
            command.Email,
            command.PasswordHash
        );

        await userRepository.CreateUserAsync(newUser);
    }
}
