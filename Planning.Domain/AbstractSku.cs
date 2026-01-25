using Planning.Domain.Contracts;

namespace Planning.Domain;

public abstract class AbstractSku
{
    public Guid Uid { get; protected set; }
    public virtual IHistoryY0Parameters HistoryY0Params {
        get {
            if (_historyY0 is not null)
            {
                return _historyY0;
            }

            var parameters = Children
                .Select(s => s.HistoryY0Params)
                .ToArray();
        
            _historyY0 = new HistoryY0Parameters(parameters);

            return _historyY0;
        }
    }
    
    public virtual IPlanningY1Parameters PlanningY1Params {
        get {
            if (_planningY1 is not null)
            {
                return _planningY1;
            }

            var parameters = Children
                .Select(s => s.PlanningY1Params)
                .ToArray();
        
            _planningY1 = new PlanningY1Parameters(parameters);

            return _planningY1;
        }
    }
    
    public virtual decimal ContributionGrowth => ((PlanningY1Params.Amount - HistoryY0Params.Amount) / HistoryY0Params.Amount) * 100;

    public virtual IReadOnlyCollection<AbstractSku> Children => new List<AbstractSku>();
    
    private IHistoryY0Parameters? _historyY0;
    private IPlanningY1Parameters? _planningY1;
}