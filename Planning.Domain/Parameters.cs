namespace Planning.Domain.Contracts;

public class Parameters
{
    public Parameters(
        int units, 
        decimal price)
    {
        Units = units;
        Price = price;
    }
    public int Units { get; }
    public decimal Price { get; }
    public decimal Amount =>  Price * Units;
}