namespace Stockly.Application.UseCases.Categories.UpdateCategoryUseCase;

public record UpdateCategoryCommand(
    Guid Id,
    string Name,
    string? Description
);
