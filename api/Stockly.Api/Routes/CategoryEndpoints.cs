using Microsoft.AspNetCore.Mvc;
using Stockly.Application.UseCases.Auth.AuthenticateUserUseCase;
using Stockly.Application.UseCases.Auth.RegisterUserUseCase;
using Stockly.Application.UseCases.Categories.CreateCategoryUseCase;
using Stockly.Application.UseCases.Categories.GetCategoriesUseCase;
using Wolverine;

namespace Stockly.Api.Routes;

public static class CategoryEndpoints
{
    public static void MapCategoryEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/categories")
            .WithTags("Categories");

        group.MapPost("/", async (CreateCategoryCommand command, IMessageBus bus) =>
        {
            var category_id = await bus.InvokeAsync<Guid>(command);
            return Results.Created($"/categories/{category_id}", new { id = category_id });
        });

        group.MapGet("/", async (IMessageBus bus) =>
        {
            var query = new GetCategoriesQuery();
            var categories = await bus.InvokeAsync<IEnumerable<CategoryListItemDto>>(query);
            return Results.Ok(categories);
        });

    }
}