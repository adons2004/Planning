using Planning.Domain;
using Planning.Domain.Calculations;

namespace Planning.Application.Queries.Results;

public class CalculationResult
{
    public CalculationResult()
    {
        
    }
    public CalculationResult(CalculatableSku sku)
    {
        Uid = sku.Uid;
        Name = sku.Name;
        HistoryY0 = new HistoryCalculationResult(sku.HistoryY0Params);
        PlanningY1 = new PlanningCalculationResult(sku.PlanningY1Params);
        ContributionGrowth = sku.ContributionGrowth;
        Children = sku.Children.Select(c => new CalculationResult(c)).ToArray();
    }
    
    public Guid Uid { get; set; }
    public string Name { get; set; }
    public CalculationResult[] Children { get; set; }
    public HistoryCalculationResult HistoryY0 { get; set; } 
    public PlanningCalculationResult PlanningY1 { get; set; }
    public decimal ContributionGrowth { get; set; }
}