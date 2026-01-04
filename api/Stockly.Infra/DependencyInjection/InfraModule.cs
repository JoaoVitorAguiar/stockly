using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stockly.Core.Enums;
using Stockly.Core.Repositories;
using Stockly.Infra.Context;
using Stockly.Infra.Repositories;

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

        return services;
    }
}
