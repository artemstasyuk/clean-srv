using AutoMapper;
using CatStore.Application.Dtos.Cat;
using CatStore.Application.MediaR.Cats.Commands.CreateCat;
using CatStore.Application.MediaR.Cats.Commands.DeleteCat;
using CatStore.Application.MediaR.Cats.Commands.UpdateCat;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CatStore.Api.Controllers;


[Route("/admin")]
[Authorize(Roles = "Admin")]
public class AdminController : ApiController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    
    public AdminController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    
    
    /// <summary>
    /// Update cat
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPut("cat/update")]
    public async Task<ActionResult> UpdateCat([FromForm] UpdateCatDto dto)
    {
        await _mediator.Send(_mapper.Map<UpdateCatCommand>(dto));
        return Ok();
    }
    
    
    /// <summary>
    /// Delete cat
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Cat.Id</returns>
    [HttpDelete("cat/delete/{id:guid}")]
    public async Task<ActionResult> DeleteCat(Guid id)
    {
        await _mediator.Send(new DeleteCatCommand() { Id = id });
        return Ok();
    }
    
    
    /// <summary>
    /// Create cat
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromForm] CreateCatDto dto)
    {
        await _mediator.Send(_mapper.Map<CreateCatCommand>(dto));
        return Ok();
    }
    
    //TODO user delete, update
}