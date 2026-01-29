namespace Planning.Models.Requests;

public class PlannerUpdateRequest
{
    public Guid SubSkuUid { get; set; }
    public int? Units { get; set; }
    public decimal? Amount { get; set; }
}