using Planning.Domain;

namespace Planning.Application.Queries.Results;

public class SubSkuResult
{
    public SubSkuResult(SubSku subSku)
    {
        Uid = subSku.Uid;
        Name = subSku.Name;
        Price = subSku.Price;
        Ratio = subSku.Ratio;
        HistoryY0 = new HistoryY0Result(subSku.HistoryY0);
        PlanningY1 = new PlanningY1Result(subSku.PlanningY1);
    }
    
    public Guid Uid { get; set; }
    public string Name { get; }
    public decimal Price { get; set;}
    public decimal Ratio { get; set; }
    public HistoryY0Result HistoryY0 { get; set; }
    public PlanningY1Result PlanningY1 { get; set; }
}