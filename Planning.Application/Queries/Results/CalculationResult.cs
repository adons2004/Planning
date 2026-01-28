namespace Planning.Application.Queries.Results;

public class CalculationResult
{
    public CalculationResult(CalculationDataResult[] data, CalculationMetadataResult[] metadata)
    {
        Data = data;
        Metadata = metadata;
    }
    public CalculationDataResult[] Data { get; set; } = [];
    public CalculationMetadataResult[] Metadata { get; set; } = [];
}