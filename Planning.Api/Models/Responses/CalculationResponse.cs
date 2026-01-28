namespace Planning.Models.Responses;

public class CalculationResponse
{
    public CalculationResponse(CalculationDataResponse[] data, CalculationMetadataResponse[] metadata)
    {
        Data = data;
        Metadata = metadata;
    }
    public CalculationDataResponse[] Data { get; set; } = [];
    public CalculationMetadataResponse[] Metadata { get; set; } = [];

}