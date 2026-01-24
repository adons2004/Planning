namespace Planning.Domain.Contracts;

public interface ISkuRepository
{
    Task<Sku> Get(long id);
}