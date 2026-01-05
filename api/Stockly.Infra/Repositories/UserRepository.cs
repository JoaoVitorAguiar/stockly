using Microsoft.EntityFrameworkCore;
using Stockly.Core.Entities;
using Stockly.Core.Repositories;
using Stockly.Infra.Context;

namespace Stockly.Infra.Repositories;

public class UserRepository(StocklyDbContext dbContext) : IUserRepository
{
    public async Task CreateUserAsync(User user)
    {
        await dbContext.Users.AddAsync(user);
        await dbContext.SaveChangesAsync();
    }

    public Task<User?> GetUserByEmailAsync(string email)
    {
        return dbContext.Users.SingleOrDefaultAsync(u => u.Email == email);
    }
}