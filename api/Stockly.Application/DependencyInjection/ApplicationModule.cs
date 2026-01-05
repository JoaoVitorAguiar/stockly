using Microsoft.Extensions.DependencyInjection;


namespace Stockly.Application.DependencyInjection;

public static class ApplicationModule
{
    public static IServiceCollection AddApplicationModule(
        this IServiceCollection services)
    {
        return services;
    }
}
