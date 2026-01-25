using Planning.Domain.Contracts;

namespace Planning.Domain;

public class Sku : AbstractSku
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

    public override IReadOnlyCollection<AbstractSku> Children => _subSkus.ToList();
    
    private List<SubSku> _subSkus = new ();
}