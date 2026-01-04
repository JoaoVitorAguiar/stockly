namespace Stockly.Application.Dtos;

public record RegisterUserDto
{
    public string Name { get; init; }
    public string email { get; init; }
    public string passwordHash { get; init; }
}