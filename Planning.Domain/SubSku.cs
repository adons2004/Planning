using Planning.Domain.Contracts;

namespace Planning.Domain;

public class SubSku : AbstractSku
{
    private SubSku(){}
    public SubSku(string name, HistoryY0 historyY0, PlanningY1 planningY1)
    {
        Uid = Guid.NewGuid();
        Name = name;
        HistoryY0 = historyY0;
        PlanningY1 = planningY1;
    }
    public Guid Uid { get; private set; }
    public string Name { get; }
    public decimal Price { get; private set;}
    public decimal Ratio { get; private set; }
    public HistoryY0 HistoryY0 { get; private set; }
    public PlanningY1 PlanningY1 { get; private set; }
    public Guid SkuUid { get; private set; }

    public override IHistoryY0Parameters HistoryY0Params => HistoryY0;
    public override IPlanningY1Parameters PlanningY1Params  => PlanningY1;
}