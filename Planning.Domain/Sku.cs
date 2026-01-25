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
    
    public Guid Uid { get; private set; }
    public string Name { get; private set; }
    
    public ICollection<SubSku> SubSkus => _subSkus;

    public void Add(SubSku subSku)
    {
        _subSkus.Add(subSku);
    }

    protected override IReadOnlyCollection<AbstractSku> Children => _subSkus.ToList();
    
    private List<SubSku> _subSkus = new ();
}