using Planning.Domain.Abstraction;

namespace Planning.Application.Contracts;

public interface IAggregateRepository<TAggregate> : IUnitOfWork
    where TAggregate : AbstractSku
{
    Task<AbstractSku[]> Get(string[] subSkuName, CancellationToken cancellationToken);
    Task<TAggregate> Get(Guid subSkuUid, CancellationToken cancellationToken);
    void Update(TAggregate sku);
}