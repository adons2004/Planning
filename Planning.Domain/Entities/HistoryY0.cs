using Planning.Domain.Attributes;
using Planning.Domain.Contracts;

namespace Planning.Domain.Entities;

public class HistoryY0 : IHistoryY0Parameters
{
    private HistoryY0()
    {
        
    }
    public HistoryY0(int units, decimal amount)
    {
        SubSkuUid = Guid.NewGuid();
        Units = units;
        Amount = amount;
    }
    
    [Metadata(false, "int")]
    public int Units { get; private set; }
    [Metadata(false, "decimal")]
    public decimal Amount { get; private set; }
    [Metadata(false, "decimal")]
    public decimal Price => Amount / Units;
    public Guid SubSkuUid { get; private set; }
    public SubSku SubSku { get; private set; }
}