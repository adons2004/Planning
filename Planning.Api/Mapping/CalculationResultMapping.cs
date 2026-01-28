using Planning.Application.Queries.Results;
using Planning.Models.Responses;

namespace Planning.Mapping;

public static class CalculationResultMapping
{
    public static CalculationResponse ToApi(this CalculationResult result)
    {
        var data = result.Data.Select(ToApi).ToArray();
        var metadata = result.Metadata.Select(ToApi).ToArray();

        return new CalculationResponse(data, metadata);
    }
    
    private static CalculationDataResponse ToApi(this CalculationDataResult dataResult)
    {
        return new CalculationDataResponse()
        {
            Uid = dataResult.Uid,
            Name = dataResult.Name,
            HistoryY0 = dataResult.HistoryY0.ToApi(),
            PlanningY1 = dataResult.PlanningY1.ToApi(),
            ContributionGrowth = Math.Round(dataResult.ContributionGrowth, 2),
            Children = dataResult.Children.Select(c => c.ToApi()).ToArray()
        };
    }
    
    private static CalculationMetadataResponse ToApi(this CalculationMetadataResult metadataResult)
    {
        return new CalculationMetadataResponse()
        {
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