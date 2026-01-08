namespace Stockly.Application.UseCases.Categories.GetCategoriesUseCase;

public record CategoryListItemDto(
    Guid Id,
    string Name,
    string? Description
);
