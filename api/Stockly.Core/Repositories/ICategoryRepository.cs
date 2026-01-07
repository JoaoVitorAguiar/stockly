using Stockly.Core.Entities;

namespace Stockly.Core.Repositories;

public interface ICategoryRepository
{
    Task CreateCategoryAsync(Category category);
    Task<Category?> GetCategoryByNameAsync(string name);
}
