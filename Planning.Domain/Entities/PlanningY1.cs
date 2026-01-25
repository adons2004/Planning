using Planning.Domain.Contracts;

namespace Planning.Domain.Entities;

public class PlanningY1 : IPlanningY1Parameters
{
    private PlanningY1()
    {
        
    }
    public PlanningY1(int units, decimal amount)
    {
        SubSkuUid = Guid.NewGuid();
        Units = units;
        Amount = amount;
    }

    public int Units { get; private set; }
    public decimal Amount { get; private set; }
    public decimal Price => Amount / Units;
    public Guid SubSkuUid { get; private set; }
    
    
    public void SetUnits(int units)
    {
        Units = units;
    }
    
    public void SetAmount(decimal amount)
    {
        Amount = amount;
    }
}