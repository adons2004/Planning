using Planning.Application.Contracts;
using Planning.Application.Queries.Request;
using Planning.Application.Queries.Results;
using Planning.Domain;
using Planning.Domain.Calculations;

namespace Planning.Application.Factories;

public class DefaultCalculationResultFactory : ICalculationResultFactory
{
    public CalculationDataResult[] Create(Level level, CalculatableSku sku)
    {
        return level switch
        {
            Level.Total => [new CalculationDataResult(sku)],
            Level.Sku => new CalculationDataResult(sku).Children,
            Level.SubSku => new CalculationDataResult(sku).Children.SelectMany(c => c.Children).ToArray(),
            _ => throw new ArgumentOutOfRangeException($"Level {level} not supported")
        };
    }
}