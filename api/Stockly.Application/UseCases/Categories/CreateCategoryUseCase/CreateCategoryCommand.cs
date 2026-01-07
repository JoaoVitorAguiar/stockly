namespace Stockly.Application.UseCases.Categories.CreateCategoryUseCase;

public record CreateCategoryCommand
{
    public string Name { get; init; }
    public string Description { get; init; }
}