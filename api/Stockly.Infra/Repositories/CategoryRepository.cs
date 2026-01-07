using Microsoft.EntityFrameworkCore;
using Stockly.Core.Entities;
using Stockly.Core.Repositories;
using Stockly.Infra.Context;

namespace Stockly.Infra.Repositories;

public class CategoryRepository(StocklyDbContext dbContext) : ICategoryRepository
{
    public async Task CreateCategoryAsync(Category category)
    {
        await dbContext.Categories.AddAsync(category);
        await dbContext.SaveChangesAsync();
    }

    public Task<Category?> GetCategoryByNameAsync(string name)
    {
        return dbContext.Categories.SingleOrDefaultAsync(c => c.Name == name);
    }
}