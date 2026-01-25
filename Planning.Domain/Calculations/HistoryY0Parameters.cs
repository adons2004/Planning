using Planning.Domain.Contracts;

namespace Planning.Domain.Calculations;

public class HistoryY0Parameters : IHistoryY0Parameters
{
    public HistoryY0Parameters(params IHistoryY0Parameters[] parameters)
    {
        var units = parameters.Sum(p => p.Units);
        var amount = parameters.Sum(p => p.Amount);
        var price = amount / units;
        
        Units = units;
        Amount = amount;
        Price = price;
    }
    public int Units { get; }
    public decimal Amount { get; }
    public decimal Price { get; }
}