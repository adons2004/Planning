using MediatR;
using Planning.Application.Queries.Request;
using Planning.Domain;
using Planning.Domain.Contracts;
using Planning.Models.Responses;

namespace Planning.Application.Queries;

public class CalculateQueryHandler : IRequestHandler<CalculateQuery, CalculationResult[]>
{
    private readonly ISkuRepository _skuRepository;

    public CalculateQueryHandler(ISkuRepository skuRepository)
    {
        _skuRepository = skuRepository;
    }
    
    public async Task<CalculationResult[]> Handle(CalculateQuery request, CancellationToken cancellationToken)
    {
        var skus = await _skuRepository.Get(request.SkuSubName, cancellationToken);
        
        var total = new TotalSku(skus);

        return request.Level switch
        {
            Level.Total => [new CalculationResult(total)],
            Level.Sku => new CalculationResult(total).Children,
            Level.SubSku => new CalculationResult(total).Children.SelectMany(c => c.Children).ToArray(),
            _ => throw new ArgumentOutOfRangeException($"Level {request.Level} not supported")
        };
    }
}