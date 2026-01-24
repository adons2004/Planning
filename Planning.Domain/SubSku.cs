using Planning.Domain.Contracts;

namespace Planning.Domain;

public class SubSku : ISku
{
    public SubSku(string name, HistoryY0 historyY0, PlanningY1 planningY1)
    {
        Name = name;
        HistoryY0 = historyY0;
        PlanningY1 = planningY1;
    }
    public long Uid { get; private set; }
    public string Name { get; }
    public decimal Price { get; private set;}
    public decimal Ratio { get; private set; }
    public HistoryY0 HistoryY0 { get; private set; }
    public PlanningY1 PlanningY1 { get; private set; }
    
    
    public Parameters GetHistoryY0Parameters()
    {
        var price = HistoryY0.Amount / HistoryY0.Units;
        
        return new Parameters(HistoryY0.Units, price);
    }

    public Parameters GetPlanningY1Parameters()
    {
        var price = PlanningY1.Amount / PlanningY1.Units;

        return new Parameters(PlanningY1.Units, price);
    }

    public decimal GetContributionGrowth() => ((PlanningY1.Amount - HistoryY0.Amount) / HistoryY0.Amount) * 100;
}