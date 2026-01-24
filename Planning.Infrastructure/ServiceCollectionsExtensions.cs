using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Planning.Domain.Contracts;
using Planning.Infrastructure.Data;
using Planning.Infrastructure.Repositories;

namespace Planning.Infrastructure;

public static class ServiceCollectionsExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddData(configuration)
            .AddRepositories();
    }

    private static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
    {
        var connection = configuration.GetConnectionString("Database")!;

        //services.AddDbContext<ApplicationDbContext>(options => options!);
        
        return services;
    }
    
    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ISkuRepository, SkuRepository>();

        return services;
    }
}