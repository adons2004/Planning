using Planning.Domain;

namespace Planning.Application.Queries.Results;

public class HistoryY0Result
{
    public HistoryY0Result(HistoryY0 historyY0)
    {
        Units = historyY0.Units;
        Amount = historyY0.Amount;
        Price = historyY0.Price;
    }
    public int Units { get; set; } 
    public decimal Amount { get; set; }
    public decimal Price { get; set; }
}