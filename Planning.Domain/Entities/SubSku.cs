using Planning.Domain.Attributes;
using Planning.Domain.Calculations;
using Planning.Domain.Contracts;

namespace Planning.Domain.Entities;

public class SubSku : CalculatableSku
{
    private SubSku(){}
    public SubSku(
        string name, 
        HistoryY0 historyY0, 
        PlanningY1 planningY1,
        decimal price,
        decimal ratio)
    {
        Uid = Guid.NewGuid();
        Name = name;
        HistoryY0 = historyY0;
        PlanningY1 = planningY1;
        Price = price;
        Ratio = ratio;
    }
    [Metadata(false, "decimal")]
    public decimal Price { get; private set;}
    [Metadata(false, "decimal")]
    public decimal Ratio { get; private set; }
    public HistoryY0 HistoryY0 { get; private set; }
    public PlanningY1 PlanningY1 { get; private set; }
    public Guid SkuUid { get; private set; }
    public Sku Sku { get; private set; }

    public override IHistoryY0Parameters HistoryY0Params => HistoryY0;

    public override IPlanningY1Parameters PlanningY1Params
    {
        get
        {
            if (_planningY1 is not null)
            {
                return _planningY1;
            }

            _planningY1 = new PlanningY1SubSkuParameters(PlanningY1.Units, PlanningY1.Amount, Price);

            return _planningY1;
        }
    }

    public override CalculatableSku? ParentCalculatable => base.ParentCalculatable ?? Sku;
}