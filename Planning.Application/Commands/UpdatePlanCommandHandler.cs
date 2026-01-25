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
        if (request.Units is < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(request.Units), "Units must be greater than zero");
        }
        
        if (request.Amount is < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(request.Units), "Amounts must be greater than zero");
        }

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