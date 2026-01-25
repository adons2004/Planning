using Planning.Domain;

namespace Planning.Application.Queries.Results;

public class PlanningY1Result
{
    public PlanningY1Result(PlanningY1 planningY1)
    {
        Units = planningY1.Units;
        Amount = planningY1.Amount;
        Price = planningY1.Price;
    }
    public int Units { get; set; } 
    public decimal Amount { get; set; }
    public decimal Price { get; set; }
}