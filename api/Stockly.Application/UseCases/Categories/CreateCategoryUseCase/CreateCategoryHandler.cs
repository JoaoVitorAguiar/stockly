using Stockly.Application.Exceptions;
using Stockly.Core.Entities;
using Stockly.Core.Repositories;
using Stockly.Core.Services;

namespace Stockly.Application.UseCases.Categories.CreateCategoryUseCase;

public static class CreateCategoryHandler
{
    public static async Task<Guid> Handle(
        CreateCategoryCommand command,
        ICategoryRepository categoryRepository
    )
    {
        var category = await categoryRepository.GetCategoryByNameAsync(command.Name);

        if (category is not null)
            throw new AlreadyExistsException($"Category '{command.Name}' already exists");


        var newCategory = new Category(
            command.Name,
            command.Description
        );

        await categoryRepository.CreateCategoryAsync(newCategory);

        return newCategory.Id;
    }
}
