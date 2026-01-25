using MediatR;
using Planning.Application.Contracts;
using Planning.Application.Queries.Request;
using Planning.Application.Queries.Results;
using Planning.Domain;
using Planning.Domain.Contracts;

namespace Planning.Application.Queries;

public class CalculateQueryHandler : IRequestHandler<CalculateQuery, CalculationResult[]>
{
    private readonly ISkuRepository _skuRepository;
    private readonly ICalculationResultFactory _calculationResultFactory;

    public CalculateQueryHandler(ISkuRepository skuRepository, ICalculationResultFactory calculationResultFactory)
    {
        _skuRepository = skuRepository;
        _calculationResultFactory = calculationResultFactory;
    }
    
    public async Task<CalculationResult[]> Handle(CalculateQuery request, CancellationToken cancellationToken)
    {
        var skus = await _skuRepository.Get(request.SkuSubName, cancellationToken);
        
        var total = new TotalSku(skus);

        return _calculationResultFactory.Create(request.Level, total);
    }
}