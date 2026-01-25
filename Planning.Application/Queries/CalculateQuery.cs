using MediatR;
using Planning.Application.Queries.Results;

namespace Planning.Application.Queries;

public sealed record CalculateQuery : IRequest<CalculateResult>;