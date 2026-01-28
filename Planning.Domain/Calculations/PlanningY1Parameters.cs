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
    
    public int Units { get; }
    public decimal Amount { get; }
    public decimal Price { get; }
}