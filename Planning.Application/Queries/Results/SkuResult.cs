using Planning.Domain;

namespace Planning.Application.Queries.Results;

public class SkuResult
{
    public SkuResult(Sku sku)
    {
        Uid = sku.Uid;
        Name = sku.Name;
        SubSkus = sku.SubSkus.Select(x => new SubSkuResult(x)).ToList();
    }
    
    public Guid Uid { get; set; }
    public string Name { get; set; }
    
    public List<SubSkuResult> SubSkus { get; set; }
}