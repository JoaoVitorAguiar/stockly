using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Stockly.Application.Exceptions;

namespace Stockly.Api.Middlewares;

public class CommonExceptionHandler(ILogger<CommonExceptionHandler> logger) : IExceptionHandler
{
    private readonly ILogger<CommonExceptionHandler> _logger = logger;

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        if (exception is NotFoundException)
        {
            return await WriteProblem(
                httpContext,
                StatusCodes.Status404NotFound,
                exception.Message,
                cancellationToken);
        }

        if (exception is AlreadyExistsException)
        {
            return await WriteProblem(
                httpContext,
                StatusCodes.Status409Conflict,
                exception.Message,
                cancellationToken);
        }

        if (exception is InvalidCredentialsException)
        {
            return await WriteProblem(
                httpContext,
                StatusCodes.Status401Unauthorized,
                exception.Message,
                cancellationToken);
        }

        return false;
    }

    private static async Task<bool> WriteProblem(
        HttpContext context,
        int status,
        string title,
        CancellationToken ct)
    {
        var problem = new ProblemDetails
        {
            Title = title,
            Status = status,
            Instance = context.Request.Path
        };

        context.Response.StatusCode = status;
        await context.Response.WriteAsJsonAsync(problem, ct);
        return true;
    }
}
