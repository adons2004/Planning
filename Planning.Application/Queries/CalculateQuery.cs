using MediatR;
using Planning.Application.Queries.Request;
using Planning.Models.Responses;

namespace Planning.Application.Queries;

public sealed record CalculateQuery(string[] SkuSubName, Level Level) : IRequest<CalculationResult[]>;