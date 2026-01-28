using Planning.Domain.Attributes;
using Planning.Domain.Contracts;

namespace Planning.Domain.Calculations;

public class PlanningY1SubSkuParameters : IPlanningY1Parameters
{
    public PlanningY1SubSkuParameters(int units, decimal amount, decimal price)
    {
        Units = units;
        Amount = amount;
        Price = price;
    }
    
    [Metadata(true, "int")]
    public int Units { get; }
    [Metadata(true, "decimal")]
    public decimal Amount { get; }
    [Metadata(false, "decimal")]
    public decimal Price { get; }
}