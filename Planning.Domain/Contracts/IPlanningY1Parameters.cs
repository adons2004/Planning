namespace Planning.Domain.Contracts;

public interface IPlanningY1Parameters
{
    public int Units { get; } 
    public decimal Price { get; }
    public decimal Amount { get; }
}