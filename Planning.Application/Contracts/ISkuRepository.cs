namespace Planning.Domain.Contracts;

public interface ISkuRepository : IUnitOfWork
{
    Task<Sku[]> Get(CancellationToken cancellationToken);
    Task<Sku> Get(Guid subSkuUid, CancellationToken cancellationToken);
    void Update(Sku sku);
}