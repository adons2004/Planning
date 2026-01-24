namespace Planning.Domain.Contracts;

public class Parameters
{
    public Parameters(int units, decimal price, decimal amount)
    {
        Units = units;
        Price = price;
        Amount = amount;
    }
    public int Units { get; }
    public decimal Price { get; }
    public decimal Amount { get; }
}