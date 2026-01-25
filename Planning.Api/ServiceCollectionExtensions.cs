using Planning.Application;
using Planning.Infrastructure;

namespace Planning;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddApi();
        services.AddApplication();
        services.AddInfrastructure(configuration);
        
        return services;
    }

    private static IServiceCollection AddApi(this IServiceCollection services)
    {
        services.AddControllers();

        //swagger
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }
    
}