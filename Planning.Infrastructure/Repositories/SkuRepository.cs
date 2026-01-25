using Microsoft.EntityFrameworkCore;
using Planning.Application.Contracts;
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

    public Task<Sku[]> Get(string[] subSkuName, CancellationToken cancellationToken)
    {
        var queryable = _dbContext.Skus.AsQueryable();

        if (subSkuName.Any())
        {
            queryable = queryable
                .Where(s => s.SubSkus.Any(ss => subSkuName.Contains(ss.Name)))
                .Include(s => s.SubSkus.Where(ss => subSkuName.Contains(ss.Name)));
        }
        
        return queryable.ToArrayAsync(cancellationToken);
    }

    public async Task<Sku> Get(Guid subSkuUid, CancellationToken cancellationToken)
    {
        return await _dbContext.Skus
            .Where(s => s.SubSkus.Any(ss => ss.Uid == subSkuUid))
            .FirstOrDefaultAsync(cancellationToken) ?? throw new ArgumentException($"Sku {subSkuUid} not found");
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