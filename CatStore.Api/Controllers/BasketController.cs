using AutoMapper;
using CatStore.Application.Baskets.Commands.AddItem;
using CatStore.Application.Baskets.Commands.ClearItems;
using CatStore.Application.Baskets.Commands.DecreaseItemQuantity;
using CatStore.Application.Baskets.Commands.RemoveItem;
using CatStore.Application.Baskets.Common;
using CatStore.Application.Baskets.Queries.GetBasket;
using CatStore.Application.Common.Dtos.Baskets;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CatStore.Api.Controllers;


[Route("/basket")]
[AllowAnonymous]
public class BasketController : ApiController
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    
    public BasketController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    
    /// <summary>
    /// Add Item
    /// </summary>
    /// <param name="addItemDto"></param>
    /// <returns>Basket</returns>
    [HttpPost("add")]
    public async Task<IActionResult> AddItem([FromForm] AddItemDto addItemDto)
    {
        var command = await _mediator.Send(_mapper.Map<AddItemCommand>(addItemDto));

        return command.Match(
            commandResult => Ok(_mapper.Map<BasketResponse>(commandResult)),
            errors => Problem(errors));
    }

    
    /// <summary>
    /// Clear Items
    /// </summary>
    /// <param name="userId"></param>
    /// <returns>Basket</returns>
    [HttpPost("clear")]
    public async Task<IActionResult> ClearItems(Guid userId)
    {
        var command = await _mediator.Send(new ClearItemsCommand() { UserId = userId });

        return command.Match(
            commandResult => Ok(_mapper.Map<BasketResponse>(commandResult)),
            errors => Problem(errors));
    }
    
    
    /// <summary>
    /// Decrease Item quantity
    /// </summary>
    /// <param name="dto"></param>
    /// <returns>Basket</returns>
    [HttpPost("decrease")]
    public async Task<IActionResult> DecreaseItemQuantity([FromForm] DecreaseItemQuantityDto dto)
    {
        var command = await _mediator.Send(_mapper.Map<DecreaseItemQuantityCommand>(dto));

        return command.Match(
            commandResult => Ok(_mapper.Map<BasketResponse>(commandResult)),
            errors => Problem(errors));
    }
    

    /// <summary>
    /// Remove Item
    /// </summary>
    /// <param name="dto"></param>
    /// <returns>Basket</returns>
    [HttpDelete("remove")]
    public async Task<IActionResult> RemoveItem([FromForm] RemoveItemDto dto)
    {
        var command = await _mediator.Send(_mapper.Map<RemoveItemCommand>(dto));

        return command.Match(
            commandResult => Ok(_mapper.Map<BasketResponse>(commandResult)),
            errors => Problem(errors));
    }
    
    
    /// <summary>
    /// GetBasket
    /// </summary>
    /// <param name="userId"></param>
    /// <returns>Basket</returns>
    [HttpGet("{userId:guid}")]
    public async Task<IActionResult> Get(Guid userId)
    {
        var command = await _mediator.Send(new GetBasketQuery(){ UserId = userId });

        return command.Match(
            commandResult => Ok(_mapper.Map<BasketResponse>(commandResult)),
            errors => Problem(errors));
    }
}