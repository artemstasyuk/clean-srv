using AutoMapper;
using CatStore.Application.Dtos.Baskets;
using CatStore.Application.MediaR.Baskets.Commands.AddItem;
using CatStore.Application.MediaR.Baskets.Commands.ClearItems;
using CatStore.Application.MediaR.Baskets.Commands.DecreaseItemQuantity;
using CatStore.Application.MediaR.Baskets.Commands.RemoveItem;
using CatStore.Application.MediaR.Baskets.Common;
using CatStore.Application.MediaR.Baskets.Queries.GetBasket;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CatStore.Api.Controllers;


[Route("/basket")]
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

    
    [HttpPost("clearItems/{userId:guid}")]
    public async Task<IActionResult> ClearItems(Guid userId)
    {
        var command = await _mediator.Send(new ClearItemsCommand() { UserId = userId });

        return command.Match(
            commandResult => Ok(_mapper.Map<BasketDto>(commandResult)),
            errors => Problem(errors));
    }
    

    [HttpPost("decreaseItemQuantity")]
    public async Task<IActionResult> DecreaseItemQuantity([FromForm] DecreaseItemQuantityDto dto)
    {
        var command = await _mediator.Send(_mapper.Map<DecreaseItemQuantityCommand>(dto));

        return command.Match(
            commandResult => Ok(_mapper.Map<BasketDto>(commandResult)),
            errors => Problem(errors));
    }
    

    [HttpPost("removeItem")]
    public async Task<IActionResult> RemoveItem([FromForm] RemoveItemDto dto)
    {
        var command = await _mediator.Send(_mapper.Map<RemoveItemCommand>(dto));

        return command.Match(
            commandResult => Ok(_mapper.Map<BasketDto>(commandResult)),
            errors => Problem(errors));
    }
    
    
    [HttpGet("basket/{userId:guid}")]
    public async Task<IActionResult> Get(Guid userId)
    {
        var command = await _mediator.Send(new GetBasketQuery(){ UserId = userId });

        return command.Match(
            commandResult => Ok(_mapper.Map<BasketDto>(commandResult)),
            errors => Problem(errors));
    }
}