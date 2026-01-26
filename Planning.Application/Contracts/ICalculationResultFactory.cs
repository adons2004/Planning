using Planning.Application.Queries.Request;
using Planning.Application.Queries.Results;
using Planning.Domain;
using Planning.Domain.Calculations;

namespace Planning.Application.Contracts;

public interface ICalculationResultFactory
{
    CalculationResult[] Create(Level level, CalculatableSku sku);
}