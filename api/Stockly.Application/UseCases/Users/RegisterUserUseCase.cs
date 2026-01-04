using Stockly.Application.Dtos;
using Stockly.Application.Exceptions;
using Stockly.Core.Entities;
using Stockly.Core.Repositories;

namespace Stockly.Application.UseCases.Users;

public sealed class RegisterUserUseCase(IUserRepository userRepository)
{
    public async Task ExecuteAsync(RegisterUserDto command)
    {
        var user = await userRepository.GetUserByEmailAsync(command.email);

        if (user is not null)
            throw new AlreadyExistsException("User already exists");

        var newUser = new User(command.Name, command.email, command.passwordHash);

        await userRepository.CreateUserAsync(newUser);
    }
}
