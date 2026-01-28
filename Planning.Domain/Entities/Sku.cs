using Planning.Domain.Calculations;
using Planning.Domain.Contracts;

namespace Planning.Domain.Entities;

public class Sku : CalculatableSku
{
    private Sku()
    {
        
    }
    public Sku(string name)
    {
        Uid = Guid.NewGuid();
        Name = name;
    }
    
    public ICollection<SubSku> SubSkus => _subSkus;

    public void Add(SubSku subSku)
    {
        subSku.SetParentCalculatable(this);
        
        _subSkus.Add(subSku);
    }

    public void UpdateSubSku(
        Guid subSkuUid, 
        int? units, 
        decimal? amount)
    {
        
        if (units is < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(units), "Units must be greater than zero");
        }
        
        if (amount is < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amounts must be greater than zero");
        }

        var subSku = SubSkus.Single(s => s.Uid == subSkuUid);

        if (units.HasValue)
        {
            subSku.PlanningY1.SetUnits(units.Value);
        }
        
        if (amount.HasValue)
        {
            subSku.PlanningY1.SetAmount(amount.Value);
        }
    }
        
    public override IHistoryY0Parameters HistoryY0Params {
        get {
            if (_historyY0 is not null)
            {
                return _historyY0;
            }

            var parameters = _subSkus
                .Select(s => new { s.Ratio, s.HistoryY0 })
                .ToArray();
            
            var units = parameters.Sum(p => (int)(p.Ratio * p.HistoryY0.Units));
            var amount = parameters.Sum(p => p.HistoryY0.Amount);
            var price = amount / units;
        
            _historyY0 = new HistoryY0Parameters(units, amount, price);

            return _historyY0;
        }
    }
    
    public override IPlanningY1Parameters PlanningY1Params {
        get {
            if (_planningY1 is not null)
            {
                return _planningY1;
            }

            var parameters = _subSkus
                .Select(s => new { s.Ratio, s.PlanningY1 })
                .ToArray();
        
            var units = parameters.Sum(p => (int)(p.Ratio * p.PlanningY1.Units));
            var amount = parameters.Sum(p => p.PlanningY1.Amount);
            var price = amount / units;

            _planningY1 = new PlanningY1Parameters(units, amount, price);

            return _planningY1;
        }
    }

    public override IReadOnlyCollection<CalculatableSku> Children => _subSkus.ToList();
    
    private List<SubSku> _subSkus = new ();
}