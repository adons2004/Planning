using Planning.Domain.Calculations;

namespace Planning.Domain.Entities;

public class Sku : CalculatableSku
{
    private Sku()
    {
        
    }
    public Sku(string name)
    {
        Uid = Guid.NewGuid();
        Name = name;
    }
    
    public ICollection<SubSku> SubSkus => _subSkus;

    public void Add(SubSku subSku)
    {
        _subSkus.Add(subSku);
    }

    public void UpdateSubSku(
        Guid subSkuUid, 
        int? units, 
        decimal? amount)
    {
        
        if (units is < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(units), "Units must be greater than zero");
        }
        
        if (amount is < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amounts must be greater than zero");
        }

        var subSku = SubSkus.Single(s => s.Uid == subSkuUid);

        if (units.HasValue)
        {
            subSku.PlanningY1.SetUnits(units.Value);
        }
        
        if (amount.HasValue)
        {
            subSku.PlanningY1.SetAmount(amount.Value);
        }
    }
    
    public override IReadOnlyCollection<CalculatableSku> Children => _subSkus.ToList();
    
    private List<SubSku> _subSkus = new ();
}