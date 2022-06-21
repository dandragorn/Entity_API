using Abstractions;
using Abstractions.Requests.AddEntity;
using Abstractions.Requests.DeleteEntity;
using Abstractions.Requests.GetEntities;
using Abstractions.Requests.UpdateEntity;
using App.Handlers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]

[ApiController]
public class EntityController : ControllerBase
{
    private IMediator? _mediator;

    private IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

    [HttpPost("/add_entity")]
    public async Task<IActionResult> Create(int id, string title, string description, string text)
    {
        return Ok(await Mediator.Send(new AddEntityRequest(id,title,description,text)));
    }

    [HttpGet("/get_entities")]
    public async Task<IActionResult> GetEntities(int skip, int show)
    {
        return Ok(await Mediator.Send(new GetEntitiesRequest(skip, show)));
    }

    [HttpPut("/update_entity/{id}")]
    public async Task<IActionResult> Update(int id, string title, string description, string content)
    {
        return Ok(await Mediator.Send(new UpdateEntityRequest(id, title, description, content)));
    }

    [HttpDelete("/delete_entity/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok(await Mediator.Send(new DeleteEntityRequest(id)));
    }
}