using MediatR;
using Microsoft.AspNetCore.Mvc;
using Planning.Application.Commands;
using Planning.Application.Queries;
using Planning.Mapping;
using Planning.Models.Requests;
using Planning.Models.Responses;

namespace Planning.Controllers;

[ApiController]
[Route(WebRoutes.Planner.BasePath)]
public class PlannerController : Controller
{
    private readonly IMediator _mediator;

    public PlannerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<CalculationResponse> Calculate(
        [FromQuery] string[] skuSubName, 
        [FromQuery] LevelRequest level = LevelRequest.Total, 
        CancellationToken cancellationToken = default)
    {
        var result = await _mediator.Send(new CalculateQuery(skuSubName, level.ToApplicationLevel()), cancellationToken);

        return result.ToApi();
    }
    
    [HttpPatch]
    public async Task Update(
        [FromBody] PlannerUpdateRequest model, 
        CancellationToken cancellationToken = default)
    {
        await _mediator.Send(new UpdatePlanCommand(
            model.SubSkuUid,
            model.Units,
            model.Amount
        ), cancellationToken);
    }
}