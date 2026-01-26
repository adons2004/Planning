namespace Planning.Domain.Calculations;

public class TotalSku : CalculatableSku
{
    public TotalSku(params CalculatableSku[] skus)
    {
        _skus = skus.ToList();
        Name = "TOTAL";
    }
    public override IReadOnlyCollection<CalculatableSku> Children => _skus;
    public IReadOnlyCollection<CalculatableSku> _skus;
}