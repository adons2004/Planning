namespace Planning.Models.Responses;

public class PlanningMetadataResponse
{
    public FieldMetadataResponse Units { get; set; }
    public FieldMetadataResponse Amount { get; set; }
    public FieldMetadataResponse Price { get; set; }
}