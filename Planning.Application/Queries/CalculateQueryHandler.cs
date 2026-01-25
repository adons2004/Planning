using MediatR;
using Planning.Domain;
using Planning.Domain.Contracts;
using Planning.Models.Responses;

namespace Planning.Application.Queries;

public class CalculateQueryHandler : IRequestHandler<CalculateQuery, CalculationResult>
{
    private readonly ISkuRepository _skuRepository;

    public CalculateQueryHandler(ISkuRepository skuRepository)
    {
        _skuRepository = skuRepository;
    }
    
    public async Task<CalculationResult> Handle(CalculateQuery request, CancellationToken cancellationToken)
    {
        var skus = await _skuRepository.Get(cancellationToken);

        var total = new TotalSku(skus);

        return new CalculationResult(total);
    }
}