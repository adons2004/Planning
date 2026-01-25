using Planning.Domain.Contracts;

namespace Planning.Models.Responses;

public class PlanningCalculationResult
{
    public PlanningCalculationResult()
    {
        
    }
    public PlanningCalculationResult(IPlanningY1Parameters parameters)
    {
        Units = parameters.Units;
        Amount = parameters.Amount;
        Price = parameters.Price;
    }
    public int Units { get; set; }
    public decimal Amount { get; set; }
    public decimal Price { get; set; }
}