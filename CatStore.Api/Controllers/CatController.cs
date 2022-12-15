using AutoMapper;
using CatStore.Application.MediaR.Cats.Queries.GetAllCats;
using CatStore.Application.MediaR.Cats.Queries.GetCatById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CatStore.Api.Controllers;

[Route("/cat")]
public class CatController : ApiController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    
    public CatController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    

    /// <summary>
    /// Get cats list
    /// </summary>
    /// <returns>CatListDto</returns>
    [HttpGet("getList")]
    public async Task<ActionResult> GetList()
    {
        var cats = await _mediator.Send(new GetAllCatsQuery());
        return Ok(cats);
    }
    
    
    /// <summary>
    /// Get cat by id 
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Cat</returns>
    [HttpGet("getCatById/{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetCatByIdQuery() { Id = id });
        return result.Match(
            catResult => Ok(catResult),
            errors => Problem(errors));
    }
}