using Planning.Application.Queries.Request;
using Planning.Application.Queries.Results;
using Planning.Domain;

namespace Planning.Application.Contracts;

public interface ICalculationResultFactory
{
    CalculationResult[] Create(Level level, AbstractSku sku);
}