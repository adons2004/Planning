using MediatR;
using Planning.Application.Contracts;
using Planning.Application.Queries.Request;
using Planning.Application.Queries.Results;
using Planning.Domain;
using Planning.Domain.Calculations;
using Planning.Domain.Contracts;
using Planning.Domain.Entities;

namespace Planning.Application.Queries;

public class CalculateQueryHandler : IRequestHandler<CalculateQuery, CalculationResult>
{
    private readonly IAggregateRepository<Sku> _aggregateRepository;
    private readonly ICalculationResultFactory _calculationResultFactory;

    public CalculateQueryHandler(
        IAggregateRepository<Sku> aggregateRepository, 
        ICalculationResultFactory calculationResultFactory)
    {
        _aggregateRepository = aggregateRepository;
        _calculationResultFactory = calculationResultFactory;
    }
    
    public async Task<CalculationResult> Handle(CalculateQuery request, CancellationToken cancellationToken)
    {
        var skus = await _aggregateRepository.Get(request.SkuSubName, cancellationToken);
        
        var total = new TotalSku(skus);

        var result = _calculationResultFactory.Create(request.Level, total);

        return result;
    }
}