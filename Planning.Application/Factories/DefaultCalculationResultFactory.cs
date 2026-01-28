using Planning.Application.Contracts;
using Planning.Application.Queries.Request;
using Planning.Application.Queries.Results;
using Planning.Domain;
using Planning.Domain.Calculations;

namespace Planning.Application.Factories;

public class DefaultCalculationResultFactory : ICalculationResultFactory
{
    public CalculationResult Create(Level level, CalculatableSku sku)
    {
        var data =  level switch
        {
            Level.Total => [new CalculationDataResult(sku)],
            Level.Sku => new CalculationDataResult(sku).Children,
            Level.SubSku => new CalculationDataResult(sku).Children.SelectMany(c => c.Children).ToArray(),
            _ => throw new ArgumentOutOfRangeException($"Level {level} not supported")
        };
        
        var metadata =  level switch
        {
            Level.Total => [new CalculationMetadataResult(sku)],
            Level.Sku => new CalculationMetadataResult(sku).Children,
            Level.SubSku => new CalculationMetadataResult(sku).Children.SelectMany(c => c.Children).ToArray(),
            _ => throw new ArgumentOutOfRangeException($"Level {level} not supported")
        };
        
        return new CalculationResult(data, metadata);
    }
}