using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Planning.Domain.Contracts;
using Planning.Infrastructure.Data;
using Planning.Infrastructure.Repositories;

namespace Planning.Infrastructure.Tests.Host;

public class InfrastructureTestHost
{
    public readonly ISkuRepository SkuRepository;
    public InfrastructureTestHost()
    {
        var services = new ServiceCollection();

        var configuration = new ConfigurationBuilder()
            .Build();
        
        services.AddInfrastructure(configuration);
        
        SkuRepository = services.BuildServiceProvider().GetRequiredService<ISkuRepository>();
    }
}