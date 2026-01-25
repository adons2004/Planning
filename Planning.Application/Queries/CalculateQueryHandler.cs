using MediatR;
using Planning.Application.Queries.Results;
using Planning.Domain;
using Planning.Domain.Contracts;

namespace Planning.Application.Queries;

public class CalculateQueryHandler : IRequestHandler<CalculateQuery, CalculateResult>
{
    private readonly ISkuRepository _skuRepository;

    public CalculateQueryHandler(ISkuRepository skuRepository)
    {
        _skuRepository = skuRepository;
    }
    
    public async Task<CalculateResult> Handle(CalculateQuery request, CancellationToken cancellationToken)
    {
        var skus = await _skuRepository.Get(cancellationToken);

        var total = new Total();
        foreach (var sku in skus)
        {
            total.Add(sku);
        }
        
        return new CalculateResult(total);
    }
}