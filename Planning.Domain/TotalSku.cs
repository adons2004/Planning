namespace Planning.Domain;

public class TotalSku : AbstractSku
{
    public TotalSku(params Sku[] skus)
    {
        Skus = skus.ToList();
    }
    public override IReadOnlyCollection<AbstractSku> Children => Skus;
    public IReadOnlyCollection<Sku> Skus { get; init; }
}