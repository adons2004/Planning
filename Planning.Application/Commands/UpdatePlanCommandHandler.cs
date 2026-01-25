using MediatR;
using Planning.Application.Contracts;
using Planning.Domain.Entities;

namespace Planning.Application.Commands;

public class UpdatePlanCommandHandler : IRequestHandler<UpdatePlanCommand, Unit>
{
    private readonly IAggregateRepository<Sku> _aggregateRepository;

    public UpdatePlanCommandHandler(IAggregateRepository<Sku> aggregateRepository)
    {
        _aggregateRepository = aggregateRepository;
    }
    
    public async Task<Unit> Handle(UpdatePlanCommand request, CancellationToken cancellationToken)
    {
        var sku = await _aggregateRepository.Get(request.SubSkuUid, cancellationToken);

        sku.UpdateSubSku(request.SubSkuUid, request.Units, request.Amount);

        _aggregateRepository.Update(sku);
        await _aggregateRepository.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}