using Lister.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lister.Infrastructure;

public static class DependancyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

        var connectionString = configuration.GetConnectionString("default");
        services.AddDbContextPool<ListerDbContext>(options =>
        options.UseMySql(
            connectionString, ServerVersion.AutoDetect(connectionString),
        b => b.MigrationsAssembly(typeof(ListerDbContext).Assembly.FullName)));

        services.AddScoped<ToDoItemService>();
        services.AddScoped<ToDoListService>();

        return services;
    }
}
