using Planning.Models.Responses;

namespace Planning.Mapping;

public static class CalculationResultMapping
{
    public static CalculationResponse ToApi(this CalculationResult result)
    {
        return new CalculationResponse()
        {
            Uid = result.Uid,
            Name = result.Name,
            HistoryY0 = result.HistoryY0.ToApi(),
            PlanningY1 = result.PlanningY1.ToApi(),
            ContributionGrowth = Math.Round(result.ContributionGrowth, 2),
            Children = result.Children.Select(c => c.ToApi()).ToArray()
        };
    }

    private static HistoryCalculationResponse ToApi(this HistoryCalculationResult result)
    {
        return new HistoryCalculationResponse()
        {
            Units = result.Units,
            Amount = result.Amount,
            Price = Math.Round(result.Price, 2)
        };
    }
    
    private static PlanningCalculationResponse ToApi(this PlanningCalculationResult result)
    {
        return new PlanningCalculationResponse()
        {
            Units = result.Units,
            Amount = result.Amount,
            Price = Math.Round(result.Price, 2)
        };
    }
}