using Planning.Domain.Attributes;
using Planning.Domain.Contracts;

namespace Planning.Domain.Calculations;

public class PlanningY1Parameters : IPlanningY1Parameters
{
    public PlanningY1Parameters(int units, decimal amount, decimal price)
    {
        Units = units;
        Amount = amount;
        Price = price;
    }
    
    [Metadata(false, "int")]
    public int Units { get; }
    [Metadata(false, "decimal")]
    public decimal Amount { get; }
    [Metadata(false, "decimal")]
    public decimal Price { get; }
}