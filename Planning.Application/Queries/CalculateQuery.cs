using MediatR;
using Planning.Application.Queries.Request;
using Planning.Application.Queries.Results;

namespace Planning.Application.Queries;

public sealed record CalculateQuery(string[] SkuSubName, Level Level) : IRequest<CalculateResult>;