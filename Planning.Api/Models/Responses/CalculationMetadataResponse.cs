namespace Planning.Models.Responses;

public class CalculationMetadataResponse
{
    
    public Guid Uid { get; set; }
    public FieldMetadataResponse Name { get; set; }
    public CalculationMetadataResponse[] Children { get; set; }
    
    public HistoryMetadataResponse HistoryY0 { get; set; } 
    public PlanningMetadataResponse PlanningY1 { get; set; }
    public FieldMetadataResponse ContributionGrowth { get; set; }
}