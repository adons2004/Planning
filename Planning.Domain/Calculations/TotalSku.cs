using Planning.Domain.Contracts;

namespace Planning.Domain.Calculations;

public class TotalSku : CalculatableSku
{
    public TotalSku(params CalculatableSku[] skus)
    {
        _skus = skus.ToList();
        Name = "TOTAL";
        foreach (var sku in _skus)
        {
            sku.SetParentCalculatable(this);
        }
    }
        
    public override IHistoryY0Parameters HistoryY0Params {
        get {
            if (_historyY0 is not null)
            {
                return _historyY0;
            }

            var parameters = Children
                .Select(s => s.HistoryY0Params)
                .ToArray();
            
            var units = parameters.Sum(p => p.Units);
            var amount = parameters.Sum(p => p.Amount);
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

            var parameters = Children
                .Select(s => s.PlanningY1Params)
                .ToArray();
        
            var units = parameters.Sum(p => p.Units);
            var amount = parameters.Sum(p => p.Amount);
            var price = amount / units;

            _planningY1 = new PlanningY1Parameters(units, amount, price);

            return _planningY1;
        }
    }
    
    public override decimal ContributionGrowth => ((PlanningY1Params.Amount - HistoryY0Params.Amount) / HistoryY0Params.Amount) * 100;

    public override IReadOnlyCollection<CalculatableSku> Children => _skus;
    private IReadOnlyCollection<CalculatableSku> _skus;
}