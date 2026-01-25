using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Planning.Domain;
using Planning.Domain.Contracts;
using Planning.Domain.Entities;

namespace Planning.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Sku> Skus { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            Assembly.GetAssembly(typeof(ApplicationDbContext))!
        );

        base.OnModelCreating(modelBuilder);
    }
}