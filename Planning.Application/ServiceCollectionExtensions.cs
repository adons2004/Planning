using Microsoft.Extensions.DependencyInjection;
using Planning.Application.Contracts;
using Planning.Application.Factories;

namespace Planning.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly));
        services.AddFactories();
        
        return services;
    }

    private static IServiceCollection AddFactories(this IServiceCollection services)
    {
        services.AddSingleton<ICalculationResultFactory, DefaultCalculationResultFactory>();
        
        return services;
    }
}