using Planning.Domain.Attributes;
using Planning.Domain.Contracts;

namespace Planning.Domain.Calculations;

public abstract class CalculatableSku
{
    static CalculatableSku()
    {
        var historyParameters = typeof(IHistoryY0Parameters).GetProperties().Select(p => p.Name).ToArray();
        var planningParameters = typeof(IPlanningY1Parameters).GetProperties().Select(p => p.Name).ToArray();
        _valueTypes = historyParameters.Concat(planningParameters).Distinct().ToArray();
    }
    
    public Guid Uid { get; protected set; }
    [Metadata(false, "string")]
    public string Name { get; protected set; }
    public static string[] ValueTypes => _valueTypes;
    public virtual IHistoryY0Parameters HistoryY0Params => _historyY0;

    public virtual IPlanningY1Parameters PlanningY1Params => _planningY1;

    [Metadata(false, "decimal")]
    public virtual decimal ContributionGrowth
    {
        get
        {
            if (_contributionGrowth.HasValue)
            {
                return _contributionGrowth.Value;
            }
            
            if (ParentCalculatable is null)
            {
                throw new InvalidOperationException("Parent sku is null");
            }
            
            return ((PlanningY1Params.Amount - HistoryY0Params.Amount) / ParentCalculatable.HistoryY0Params.Amount) * 100;
        }
    }

    public virtual IReadOnlyCollection<CalculatableSku> Children => new List<CalculatableSku>();
    
    public virtual CalculatableSku? ParentCalculatable => _parentCalculatable;
    
    public void SetParentCalculatable(CalculatableSku parentCalculatable)
    {
        _parentCalculatable = parentCalculatable;
    }
    
    protected IHistoryY0Parameters? _historyY0;
    protected IPlanningY1Parameters? _planningY1;
    protected decimal? _contributionGrowth;
    private CalculatableSku? _parentCalculatable;
    private static string[] _valueTypes;
}