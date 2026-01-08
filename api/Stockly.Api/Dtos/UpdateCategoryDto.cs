namespace Stockly.Api.Dtos;

public record UpdateCategoryDto(
    string Name,
    string? Description
);
