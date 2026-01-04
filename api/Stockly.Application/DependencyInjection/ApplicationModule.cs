using Microsoft.Extensions.DependencyInjection;
using Stockly.Application.UseCases.Users;

namespace Stockly.Application.DependencyInjection;

public static class ApplicationModule
{
    public static IServiceCollection AddApplicationModule(
        this IServiceCollection services)
    {
        services.AddScoped<RegisterUserUseCase>();

        return services;
    }
}
