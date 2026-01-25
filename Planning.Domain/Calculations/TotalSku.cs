using Planning.Domain.Abstraction;

namespace Planning.Domain.Calculations;

public class TotalSku : AbstractSku
{
    public TotalSku(params AbstractSku[] skus)
    {
        _skus = skus.ToList();
        Name = "TOTAL";
    }
    public override IReadOnlyCollection<AbstractSku> Children => _skus;
    public IReadOnlyCollection<AbstractSku> _skus;
}