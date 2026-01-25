using Planning.Domain;

namespace Planning.Models.Responses;

public class CalculationResult
{
    public CalculationResult()
    {
        
    }
    public CalculationResult(AbstractSku sku)
    {
        HistoryY0 = new HistoryCalculationResult(sku.HistoryY0Params);
        PlanningY1 = new PlanningCalculationResult(sku.PlanningY1Params);
        Children = sku.Children.Select(c => new CalculationResult(c)).ToArray();
    }
    
    public HistoryCalculationResult HistoryY0 { get; set; } 
    public PlanningCalculationResult PlanningY1 { get; set; }
    
    public CalculationResult[] Children { get; set; }
}