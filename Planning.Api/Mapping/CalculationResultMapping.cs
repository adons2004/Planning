using Planning.Models.Responses;

namespace Planning.Mapping;

public static class CalculationResultMapping
{
    public static CalculationResponse ToApi(this CalculationResult result)
    {
        return new CalculationResponse()
        {
            HistoryY0 = result.HistoryY0.ToApi(),
            PlanningY1 = result.PlanningY1.ToApi(),
            Children = result.Children.Select(c => c.ToApi()).ToArray()
        };
    }

    private static HistoryCalculationResponse ToApi(this HistoryCalculationResult result)
    {
        return new HistoryCalculationResponse()
        {
            Units = result.Units,
            Amount = result.Amount,
            Price = result.Price
        };
    }
    
    private static PlanningCalculationResponse ToApi(this PlanningCalculationResult result)
    {
        return new PlanningCalculationResponse()
        {
            Units = result.Units,
            Amount = result.Amount,
            Price = result.Price
        };
    }
}