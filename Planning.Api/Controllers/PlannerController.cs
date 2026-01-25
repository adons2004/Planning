using MediatR;
using Microsoft.AspNetCore.Mvc;
using Planning.Application.Commands;
using Planning.Application.Queries;
using Planning.Mapping;
using Planning.Models.Requests;

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
    public async Task<ActionResult<string>> Calculate(
        [FromQuery] string[] skuSubName, 
        [FromQuery] LevelRequest level = LevelRequest.Total, 
        CancellationToken cancellationToken = default)
    {
        await _mediator.Send(new CalculateQuery(skuSubName, level.ToApplicationLevel()), cancellationToken);
        
        throw new NotImplementedException();
    }
    
    [HttpPatch(WebRoutes.Planner.Update)]
    public async Task<ActionResult<string>> Update(
        [FromRoute] Guid subSkuUid, 
        [FromBody] PlannerUpdateRequest model, 
        CancellationToken cancellationToken = default)
    {
        await _mediator.Send(new UpdatePlanCommand(
            subSkuUid,
            model.Units,
            model.Amount
        ), cancellationToken);
        
        throw new NotImplementedException();
    }
}