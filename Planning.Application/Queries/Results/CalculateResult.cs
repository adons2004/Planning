using Planning.Domain;

namespace Planning.Application.Queries.Results;

public class CalculateResult
{
    public CalculateResult(Total total)
    {
        foreach (var sku in total.Skus)
        {
            Skus.Add(new SkuResult(sku));
        }
    }

    public List<SkuResult> Skus { get; set; } = new();
}