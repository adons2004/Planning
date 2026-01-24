using Microsoft.EntityFrameworkCore;
using Planning.Domain;
using Planning.Domain.Contracts;
using Planning.Infrastructure.Data;

namespace Planning.Infrastructure.Repositories;

public class SkuRepository : ISkuRepository
{
    private readonly ApplicationDbContext _dbContext;

    public SkuRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Sku[]> Get(CancellationToken cancellationToken)
    {
        return await _dbContext.Skus
            .ToArrayAsync(cancellationToken);
    }

    public async Task<Sku> Get(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.Skus
            .FirstOrDefaultAsync(s => s.Uid == id, cancellationToken) ?? throw new ArgumentException($"Sku {id} not found");
    }

    public void Update(Sku sku)
    {
        _dbContext.Skus.Update(sku);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public void SaveChanges()
    {
        _dbContext.SaveChanges();
    }
}