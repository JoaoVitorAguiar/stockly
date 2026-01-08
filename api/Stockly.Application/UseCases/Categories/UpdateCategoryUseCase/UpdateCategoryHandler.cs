using Stockly.Application.Exceptions;
using Stockly.Core.Repositories;

namespace Stockly.Application.UseCases.Categories.UpdateCategoryUseCase;

public static class UpdateCategoryHandler
{
    public static async Task Handle(
        UpdateCategoryCommand command,
        ICategoryRepository categoryRepository)
    {
        var existingCategory = await categoryRepository.GetCategoryByIdAsync(command.Id)
            ?? throw new NotFoundException($"Category with id '{command.Id}' was not found.");

        var duplicateCategory = await categoryRepository.GetCategoryByNameAsync(command.Name);

        if (duplicateCategory is not null && duplicateCategory.Id != existingCategory.Id)
            throw new AlreadyExistsException($"A category with name '{command.Name}' already exists.");

        existingCategory.Update(command.Name, command.Description);

        await categoryRepository.UpdateCategoryAsync(existingCategory);
    }
}