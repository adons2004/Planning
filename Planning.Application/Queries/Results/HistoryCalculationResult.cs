using Planning.Domain.Contracts;

namespace Planning.Application.Queries.Results;

public class HistoryCalculationResult
{
    public HistoryCalculationResult()
    {
        
    }
    public HistoryCalculationResult(IHistoryY0Parameters parameters)
    {
        Units = parameters.Units;
        Amount = parameters.Amount;
        Price = parameters.Price;
    }
    public int Units { get; set; }
    public decimal Amount { get; set; }
    public decimal Price { get; set; }
}