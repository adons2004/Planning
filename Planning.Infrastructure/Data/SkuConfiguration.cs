using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planning.Domain;

namespace Planning.Infrastructure.Data;

public class SkuConfiguration : IEntityTypeConfiguration<Sku>
{
    public void Configure(EntityTypeBuilder<Sku> builder)
    {
        builder.HasKey(b => b.Uid);
        builder.Property(b => b.Uid).IsRequired();
        builder.Property(b => b.Name).IsRequired();

        builder.OwnsMany(e => e.SubSkus, subSkuBuilder =>
        {
            subSkuBuilder.HasKey(b => b.Uid);
            subSkuBuilder.Property(b => b.Uid).IsRequired();
            subSkuBuilder.Property(b => b.Name).IsRequired();
            subSkuBuilder.Property(b => b.Price).IsRequired();
            subSkuBuilder.Property(b => b.Ratio).IsRequired();
            subSkuBuilder.OwnsOne(e => e.HistoryY0, historyY0Builder =>
            {
                historyY0Builder.Property(b => b.Amount).IsRequired();
                historyY0Builder.Property(b => b.Units).IsRequired();
            });
            subSkuBuilder.OwnsOne(e => e.PlanningY1, historyY0Builder =>
            {
                historyY0Builder.Property(b => b.Amount).IsRequired();
                historyY0Builder.Property(b => b.Units).IsRequired();
            });
            subSkuBuilder.Property(b => b.Ratio).IsRequired();
            
        });
        
        builder.Ignore(b => b.SubSkus);
    }
}