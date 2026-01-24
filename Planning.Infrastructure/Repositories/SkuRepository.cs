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
    
    public async Task<Sku> Get(long id)
    {
        return await _dbContext.Skus.FirstOrDefaultAsync(s => s.Uid == id) ?? throw new ArgumentException($"Sku {id} not found");
    }
}