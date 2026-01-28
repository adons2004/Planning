using Planning.Domain;

namespace Planning.Models.Responses;

public class CalculationDataResponse
{
    public Guid Uid { get; set; }
    public string Name { get; set; }
    public CalculationDataResponse[] Children { get; set; }
    
    public HistoryCalculationResponse HistoryY0 { get; set; } 
    public PlanningCalculationResponse PlanningY1 { get; set; }
    public decimal ContributionGrowth { get; set; }
}