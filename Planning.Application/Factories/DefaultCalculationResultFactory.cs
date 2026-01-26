using Planning.Application.Contracts;
using Planning.Application.Queries.Request;
using Planning.Application.Queries.Results;
using Planning.Domain;
using Planning.Domain.Calculations;

namespace Planning.Application.Factories;

public class DefaultCalculationResultFactory : ICalculationResultFactory
{
    public CalculationResult[] Create(Level level, CalculatableSku sku)
    {
        return level switch
        {
            Level.Total => [new CalculationResult(sku)],
            Level.Sku => new CalculationResult(sku).Children,
            Level.SubSku => new CalculationResult(sku).Children.SelectMany(c => c.Children).ToArray(),
            _ => throw new ArgumentOutOfRangeException($"Level {level} not supported")
        };
    }
}