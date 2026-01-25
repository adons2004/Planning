using Planning.Domain;

namespace Planning.Application.Queries.Results;

public class CalculateResult
{
    public CalculateResult(TotalSku totalSku)
    {
        foreach (var sku in totalSku.Skus)
        {
            Skus.Add(new SkuResult(sku));
        }
    }

    public List<SkuResult> Skus { get; set; } = new();
}