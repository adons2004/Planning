using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planning.Domain;
using Planning.Domain.Abstraction;

namespace Planning.Infrastructure.Data;

public class AbstractSubConfiguration : IEntityTypeConfiguration<AbstractSku>
{
    public void Configure(EntityTypeBuilder<AbstractSku> builder)
    {
        builder.HasKey(e => e.Uid);
        builder.Property(e => e.Name).IsRequired();
        builder.Ignore(b => b.HistoryY0Params);
        builder.Ignore(b => b.PlanningY1Params);
        builder.Ignore(b => b.ContributionGrowth);
        builder.Ignore(b => b.Children);
    }
}