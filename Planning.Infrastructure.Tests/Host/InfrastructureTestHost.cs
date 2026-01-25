using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Planning.Application.Contracts;
using Planning.Domain.Contracts;
using Planning.Domain.Entities;
using Planning.Infrastructure.Data;
using Planning.Infrastructure.Repositories;

namespace Planning.Infrastructure.Tests.Host;

public class InfrastructureTestHost
{
    public readonly IAggregateRepository<Sku> AggregateRepository;
    public InfrastructureTestHost()
    {
        var services = new ServiceCollection();

        var configuration = new ConfigurationBuilder()
            .Build();
        
        services.AddInfrastructure(configuration);
        
        AggregateRepository = services.BuildServiceProvider().GetRequiredService<IAggregateRepository<Sku>>();
    }
}