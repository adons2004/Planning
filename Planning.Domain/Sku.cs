using Planning.Domain.Contracts;

namespace Planning.Domain;

public class Sku : ISku
{
    public Sku(string name)
    {
        Name = name;
    }
    
    public long Uid { get; private set; }
    public string Name { get; private set; }

    public ICollection<SubSku> SubSkus => _subSkus;
    
    public Parameters GetHistoryY0Parameters() => Calculate(_historyY0, s => s.GetHistoryY0Parameters());
    public Parameters GetPlanningY1Parameters() => Calculate(_planningY1, s => s.GetPlanningY1Parameters());
    public decimal GetContributionGrowth() => ((GetPlanningY1Parameters().Amount - GetHistoryY0Parameters().Amount) / GetHistoryY0Parameters().Amount) * 100;
    
    private List<SubSku> _subSkus = new ();

    private Parameters? _historyY0;
    private Parameters? _planningY1;
    
    private Parameters Calculate(Parameters? current, Func<ISku, Parameters> selector)
    {
        if (current is not null)
        {
            return current;
        }

        var parameters = SubSkus.Select(selector).ToList();
        
        var units = parameters.Sum(p => p.Units);
        var amount = parameters.Sum(p => p.Amount);
        var price = amount / units;

        current = new Parameters(units, price);

        return current;
    }
}