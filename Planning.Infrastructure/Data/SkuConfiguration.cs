using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planning.Domain;

namespace Planning.Infrastructure.Data;

public class SkuConfiguration : IEntityTypeConfiguration<Sku>
{
    public void Configure(EntityTypeBuilder<Sku> builder)
    {
        var drinksSkuUid = Guid.Parse("0B1BAB69-C3D8-45A7-9264-AE590EB65E84");
        var foodsSkuUid = Guid.Parse("451F4F7A-010D-485B-B90E-6C23B8E65305");
        var cokeUid = Guid.Parse("ACE57827-9163-43B5-A928-A5325DF0D3E8");
        var waterUid = Guid.Parse("6903EC64-BA3D-4247-8F09-391AAC12A7B9");
        var burgerUid = Guid.Parse("EC095083-F006-4323-94C7-D467E3637CB7");
        var friesUid = Guid.Parse("ADF2C8C4-9BC4-47FE-B66C-49DFFEB71915");
        
        builder.HasKey(b => b.Uid);
        builder.Property(b => b.Uid).IsRequired();
        builder.Property(b => b.Name).IsRequired();

        builder.OwnsMany(e => e.SubSkus, subSkuBuilder =>
        {
            subSkuBuilder.WithOwner().HasForeignKey(b => b.SkuUid);
            subSkuBuilder.HasKey(b => b.Uid);
            subSkuBuilder.Property(b => b.Uid).IsRequired();
            subSkuBuilder.Property(b => b.Name).IsRequired();
            subSkuBuilder.Property(b => b.Price).IsRequired();
            subSkuBuilder.Property(b => b.Ratio).IsRequired();
            subSkuBuilder.OwnsOne(e => e.HistoryY0, historyY0Builder =>
            {
                historyY0Builder.WithOwner().HasForeignKey(b => b.SubSkuUid);
                historyY0Builder.Property(b => b.Amount).IsRequired();
                historyY0Builder.Property(b => b.Units).IsRequired();

                historyY0Builder.HasData(
                    new { SubSkuUid = cokeUid, Units = 1_000, Amount = 80_000m },
                    new { SubSkuUid = waterUid, Units = 2_000, Amount = 20_000m },
                    new { SubSkuUid = burgerUid, Units = 1_000, Amount = 600_000m },
                    new { SubSkuUid = friesUid, Units = 2_000, Amount = 380_000m }
                );
            });
            subSkuBuilder.OwnsOne(e => e.PlanningY1, planningY1Builder =>
            {
                planningY1Builder.WithOwner().HasForeignKey(b => b.SubSkuUid);
                planningY1Builder.Property(b => b.Amount).IsRequired();
                planningY1Builder.Property(b => b.Units).IsRequired();
                
                planningY1Builder.HasData(
                    new { SubSkuUid = cokeUid, Units = 1_200, Amount = 102_000m },
                    new { SubSkuUid = waterUid, Units = 2_100, Amount = 88_200m },
                    new { SubSkuUid = burgerUid, Units = 1_200, Amount = 840_000m },
                    new { SubSkuUid = friesUid, Units = 2_100, Amount = 441_000m }
                );
            });
            subSkuBuilder.Property(b => b.Ratio).IsRequired();
            
            subSkuBuilder.HasData(
                new
                {
                    Uid = cokeUid,
                    Name = "Кола 0.5л",
                    SkuUid = drinksSkuUid,
                    Price = 0m,
                    Ratio = 0m
                },
                new
                {
                    Uid = waterUid,
                    Name = "Вода 1.5л",
                    SkuUid = drinksSkuUid,
                    Price = 0m,
                    Ratio = 0m
                },
                new
                {
                    Uid = burgerUid,
                    Name = "Бургер",
                    SkuUid = foodsSkuUid,
                    Price = 0m,
                    Ratio = 0m
                },
                new
                {
                    Uid = friesUid,
                    Name = "Картофель-фри",
                    SkuUid = foodsSkuUid,
                    Price = 0m,
                    Ratio = 0m
                }
            );
        });
        
        builder.HasData(
            new { Uid = drinksSkuUid, Name = "Напитки" },
            new { Uid = foodsSkuUid, Name = "Еда" }
        );
    }
}