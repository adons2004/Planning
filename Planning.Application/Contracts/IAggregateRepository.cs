using Planning.Domain.Calculations;

namespace Planning.Application.Contracts;

public interface IAggregateRepository<TAggregate> : IUnitOfWork
    where TAggregate : CalculatableSku
{
    Task<CalculatableSku[]> Get(string[] subSkuName, CancellationToken cancellationToken);
    Task<TAggregate> Get(Guid subSkuUid, CancellationToken cancellationToken);
    void Update(TAggregate sku);
}