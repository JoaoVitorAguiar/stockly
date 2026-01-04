using Stockly.Application.Dtos;
using Stockly.Application.UseCases.Users;

namespace Stockly.Api.Routes;

public static class AuthEndpoints
{
    public static void MapAuthEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/auth")
            .WithTags("Authentication");

        group.MapPost("/sign-up", async (RegisterUserDto dto, RegisterUserUseCase useCase) =>
        {
            await useCase.ExecuteAsync(dto);

            return Results.Created("/auth/sign-up", new
            {
                message = "User created successfully"
            });
        });
    }
}