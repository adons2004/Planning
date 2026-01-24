namespace Planning.Domain;

public class HistoryY0
{
    private HistoryY0()
    {
        
    }
    public HistoryY0(Guid subSkuId, int units, decimal amount)
    {
        SubSkuUid = subSkuId;
        Units = units;
        Amount = amount;
    }
    
    public int Units { get; private set; } 
    public decimal Amount { get; private set; }
    public Guid SubSkuUid { get; private set; }
}