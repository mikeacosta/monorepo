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
}