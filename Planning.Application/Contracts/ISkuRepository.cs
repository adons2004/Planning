namespace Planning.Domain.Contracts;

public interface ISkuRepository : IUnitOfWork
{
    Task<Sku[]> Get(CancellationToken cancellationToken);
    Task<Sku> Get(Guid id, CancellationToken cancellationToken);
    void Update(Sku sku);
}