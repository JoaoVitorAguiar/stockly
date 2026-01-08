using Stockly.Core.Repositories;

namespace Stockly.Application.UseCases.Categories.GetCategoriesUseCase;

public class GetCategoriesHandler
{
    public static async Task<IEnumerable<CategoryListItemDto>> Handle(
        GetCategoriesQuery _,
        ICategoryRepository repository
    )
    {
        var categories = await repository.GetCategoriesAsync();

        return categories.Select(c => new CategoryListItemDto(
            c.Id,
            c.Name,
            c.Description
        ));
    }
}
