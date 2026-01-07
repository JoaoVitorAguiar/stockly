using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stockly.Core.Enums;
using Stockly.Core.Repositories;
using Stockly.Core.Services;
using Stockly.Infra.Context;
using Stockly.Infra.Repositories;
using Stockly.Infra.Services;

namespace Stockly.Infra.DependencyInjection;

public static class InfraModule
{
    public static IServiceCollection AddInfraModule(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<StocklyDbContext>(opt =>
            opt.UseNpgsql(
                configuration.GetConnectionString("DefaultConnection"),
                o => o.MapEnum<Role>("role")
            ));
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IHashService, BCryptHashService>();

        services.AddAuthenticationModule(configuration);

        return services;
    }
}
