using Planning.Domain.Contracts;

namespace Planning.Domain;

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

    
    public int Units { get; private set; }
    public decimal Amount { get; private set; }
    public decimal Price => Amount / Units;
    public Guid SubSkuUid { get; private set; }
}