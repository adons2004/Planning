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
            Uid = metadataResult.Uid,
            Name = metadataResult.Name.ToApi(),
            HistoryY0 = metadataResult.HistoryY0.ToApi(),
            PlanningY1 = metadataResult.PlanningY1.ToApi(),
            ContributionGrowth = metadataResult.ContributionGrowth.ToApi(),
            Children = metadataResult.Children.Select(c => c.ToApi()).ToArray()
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

    private static HistoryMetadataResponse ToApi(this HistoryMetadataResult result)
    {
        return new HistoryMetadataResponse()
        {
            Units = result.Units.ToApi(),
            Amount = result.Amount.ToApi(),
            Price = result.Price.ToApi()
        };
    }
    
    private static PlanningMetadataResponse ToApi(this PlanningMetadataResult result)
    {
        return new PlanningMetadataResponse()
        {
            Units = result.Units.ToApi(),
            Amount = result.Amount.ToApi(),
            Price = result.Price.ToApi()
        };
    }
    
    private static FieldMetadataResponse ToApi(this FieldMetadataResult metadata)
    {
        return new FieldMetadataResponse()
        {
            IsEditable = metadata.IsEditable,
            Type = metadata.Type
        };
    }
}