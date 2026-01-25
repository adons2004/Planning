using MediatR;
using Planning.Domain.Contracts;

namespace Planning.Application.Commands;

public class UpdatePlanCommandHandler : IRequestHandler<UpdatePlanCommand, Unit>
{
    private readonly ISkuRepository _skuRepository;

    public UpdatePlanCommandHandler(ISkuRepository skuRepository)
    {
        _skuRepository = skuRepository;
    }
    
    public async Task<Unit> Handle(UpdatePlanCommand request, CancellationToken cancellationToken)
    {
        var sku = await _skuRepository.Get(request.SubSkuUid, cancellationToken);
        
        var subSku = sku.SubSkus.Single(s => s.Uid == request.SubSkuUid);

        if (request.Units.HasValue)
        {
            subSku.PlanningY1.SetUnits(request.Units.Value);
        }
        
        if (request.Amount.HasValue)
        {
            subSku.PlanningY1.SetAmount(request.Amount.Value);
        }
        
        _skuRepository.Update(sku);
        await _skuRepository.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}