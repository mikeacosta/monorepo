using Application.Gimmicks.Commands;
using Application.Gimmicks.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class GimmicksController() : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Gimmick>>> GetGimmicks()
    {
        return await Mediator.Send(new GetGimmicksList.Query());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Gimmick>> GetGimmick(string id)
    {
        return await Mediator.Send(new GetGimmickDetails.Query { Id = id });
    }

    [HttpPost]
    public async Task<ActionResult<string>> CreateGimmick(Gimmick gimmick)
    {
        return await Mediator.Send(new CreateGimmick.Command { Gimmick = gimmick });
    }
}