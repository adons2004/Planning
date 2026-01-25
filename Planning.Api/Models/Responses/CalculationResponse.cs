using Planning.Domain;

namespace Planning.Models.Responses;

public class CalculationResponse
{
    public string Name { get; set; }
    public CalculationResponse[] Children { get; set; }
    
    public HistoryCalculationResponse HistoryY0 { get; set; } 
    public PlanningCalculationResponse PlanningY1 { get; set; }
    public decimal ContributionGrowth { get; set; }
}