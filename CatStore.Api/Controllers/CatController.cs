using AutoMapper;
using CatStore.Application.Cats.Common;
using CatStore.Application.Cats.Queries.GetAllCats;
using CatStore.Application.Cats.Queries.GetCatById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CatStore.Api.Controllers;

[Route("/cat")]
[AllowAnonymous]
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
    [HttpGet("cats")]
    public async Task<IActionResult> GetList()
    {
        var requestResult = await _mediator.Send(
            new GetAllCatsQuery());
        return requestResult.Match(
            result => Ok(result),
            errors => Problem(errors));
    }
    
    
    /// <summary>
    /// Get cat by id 
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Cat</returns>
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var requestResult = await _mediator.Send(
            new GetCatByIdQuery() { Id = id });
        
        return requestResult.Match(
            result => Ok(_mapper.Map<CatResponse>(result)),
            errors => Problem(errors));
    }
}