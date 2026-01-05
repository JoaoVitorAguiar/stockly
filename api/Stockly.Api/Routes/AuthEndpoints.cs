using Stockly.Application.UseCases.Auth.RegisterUserUseCase;
using Wolverine;

namespace Stockly.Api.Routes;

public static class AuthEndpoints
{
    public static void MapAuthEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/auth")
            .WithTags("Authentication");

        group.MapPost("/sign-up", async (RegisterUserCommand command, IMessageBus bus) =>
        {
            await bus.InvokeAsync(command);
            return Results.Created("/auth/sign-up", new
            {
                message = "User registered successfully"
            });
        });
    }
}