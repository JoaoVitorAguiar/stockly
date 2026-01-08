using Stockly.Core.Entities;

namespace Stockly.Core.Repositories;

public interface ICategoryRepository
{
    Task CreateCategoryAsync(Category category);
    Task UpdateCategoryAsync(Category category);
    Task<Category?> GetCategoryByIdAsync(Guid id);
    Task<Category?> GetCategoryByNameAsync(string name);
    Task<IList<Category>> GetCategoriesAsync();
}
