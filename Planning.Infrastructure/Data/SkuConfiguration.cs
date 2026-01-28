using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planning.Domain;
using Planning.Domain.Entities;

namespace Planning.Infrastructure.Data;

public class SkuConfiguration : IEntityTypeConfiguration<Sku>
{
    public void Configure(EntityTypeBuilder<Sku> builder)
    {
        builder.Property(b => b.Uid).IsRequired();
        builder.Property(b => b.Name).IsRequired();
        builder.Ignore(b => b.HistoryY0Params);
        builder.Ignore(b => b.PlanningY1Params);
        builder.Ignore(b => b.ContributionGrowth);
        builder.Ignore(b => b.Children);
        builder.Ignore(b => b.ParentCalculatable);

        builder.OwnsMany(e => e.SubSkus, subSkuBuilder =>
        {
            subSkuBuilder.WithOwner(e => e.Sku).HasForeignKey(b => b.SkuUid);
            subSkuBuilder.HasKey(b => b.Uid);
            subSkuBuilder.Property(b => b.Uid).IsRequired();
            subSkuBuilder.Property(b => b.Name).IsRequired();
            subSkuBuilder.Property(b => b.Price).IsRequired();
            subSkuBuilder.Property(b => b.Ratio).IsRequired();
            subSkuBuilder.Ignore(b => b.HistoryY0Params);
            subSkuBuilder.Ignore(b => b.PlanningY1Params);
            subSkuBuilder.Ignore(b => b.ContributionGrowth);
            subSkuBuilder.Ignore(b => b.Children);
            subSkuBuilder.Ignore(b => b.ParentCalculatable);
            
            subSkuBuilder.OwnsOne(e => e.HistoryY0, historyY0Builder =>
            {
                historyY0Builder.WithOwner(e => e.SubSku).HasForeignKey(b => b.SubSkuUid);
                historyY0Builder.Property(b => b.Amount).IsRequired();
                historyY0Builder.Property(b => b.Units).IsRequired();

                historyY0Builder.HasData(SeedData.SkuHistorySeed());
            });
            subSkuBuilder.OwnsOne(e => e.PlanningY1, planningY1Builder =>
            {
                planningY1Builder.WithOwner().HasForeignKey(b => b.SubSkuUid);
                planningY1Builder.Property(b => b.Amount).IsRequired();
                planningY1Builder.Property(b => b.Units).IsRequired();
                
                planningY1Builder.HasData(SeedData.SkuPlanningSeed());
            });
            subSkuBuilder.Property(b => b.Ratio).IsRequired();
            
            subSkuBuilder.HasData(SeedData.SubSkuSeed());
        });
        
        builder.HasData(SeedData.SkuSeed());
    }
}