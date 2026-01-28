using System.Reflection;
using Planning.Domain.Attributes;
using Planning.Domain.Calculations;

namespace Planning.Application.Queries.Results;

public class CalculationMetadataResult
{
    public CalculationMetadataResult(CalculatableSku sku)
    {
        var properties = sku.GetType().GetProperties()
            .ToDictionary(p => p.Name, p => p.GetCustomAttribute<MetadataAttribute>());
        
        Uid = sku.Uid;
        Name = new FieldMetadataResult(properties[nameof(CalculatableSku.Name)]!);
        HistoryY0 = new HistoryMetadataResult(sku.HistoryY0Params);
        PlanningY1 = new PlanningMetadataResult(sku.PlanningY1Params);
        ContributionGrowth = new FieldMetadataResult(properties[nameof(CalculatableSku.ContributionGrowth)]!);
        Children = sku.Children.Select(c => new CalculationMetadataResult(c)).ToArray();
    }
    
    public Guid Uid { get; set; }
    public FieldMetadataResult Name { get; set; }
    public CalculationMetadataResult[] Children { get; set; }
    public HistoryMetadataResult HistoryY0 { get; set; } 
    public PlanningMetadataResult PlanningY1 { get; set; }
    public FieldMetadataResult ContributionGrowth { get; set; }
}