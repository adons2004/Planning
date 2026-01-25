using MediatR;

namespace Planning.Application.Commands;

public sealed record UpdatePlanCommand(Guid SkuUid, Guid SubSkuUid, int? Units = null, decimal? Amount = null) : IRequest<Unit>;