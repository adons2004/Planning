using Planning.Domain.Contracts;

namespace Planning.Domain;

public class Product : ISku
{
    public Product(string name, Parameters historyY0, Parameters planningY1)
    {
        Name = name;
        HistoryY0 = historyY0;
        PlanningY1 = planningY1;
    }
    public string Name { get; }
    public Parameters HistoryY0 { get; }
    public Parameters PlanningY1 { get; }
    public decimal ContributionGrouth => ((PlanningY1.Amount - HistoryY0.Amount) / HistoryY0.Amount) * 100;

    public void Add(ISku sku)
    {
    }
}