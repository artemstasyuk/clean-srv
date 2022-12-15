using AutoMapper;
using CatStore.Application.Dtos.Baskets;
using CatStore.Application.MediaR.Baskets.Commands.AddItem;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CatStore.Api.Controllers;


[Microsoft.AspNetCore.Components.Route("/basket")]
public class BasketController : ApiController
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    
    public BasketController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost("addItem")]
    public async Task<IActionResult> AddItem([FromForm] AddItemDto addItemDto)
    {
        var command = await _mediator.Send(_mapper.Map<AddItemCommand>(addItemDto));

        return command.Match(
            commandResult => Ok(_mapper.Map<BasketDto>(commandResult)),
            errors => Problem(errors));
    }
}