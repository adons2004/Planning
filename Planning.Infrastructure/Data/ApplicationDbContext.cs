using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Planning.Domain;

namespace Planning.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Sku> Skus { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(
            Assembly.GetAssembly(typeof(ApplicationDbContext))!
        );
    }
}