using Stockly.Core.Entities;

namespace Stockly.Core.Repositories;

public interface IUserRepository
{
    Task CreateUserAsync(User user);
    Task<User?> GetUserByEmailAsync(string email);
}
