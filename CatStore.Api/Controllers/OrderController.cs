using AutoMapper;
using CatStore.Application.Common.Dtos.Order;
using CatStore.Application.Orders.Commands.CreateOrder;
using CatStore.Application.Orders.Common;
using CatStore.Application.Orders.Queries.GetAllUserOrders;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CatStore.Api.Controllers;

[Route("/order")]
[Authorize(Roles = "Customer, Admin")]
public class OrderController : ApiController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public OrderController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    
    /// <summary>
    /// Get all orders by userId
    /// </summary>
    /// <param name="userId"></param>
    /// <returns>List of Orders</returns>
    [HttpGet("user/orders")]
    public async Task<IActionResult> GetAllUserOrders(Guid userId)
    {
        var requestResult = await _mediator.Send(
            new GetAllUserOrdersQuery(){ UserId = userId});

        return requestResult.Match(
            result => Ok(_mapper.Map<List<OrderResponse>>(result)),
            errors => Problem(errors));
    }
    
    /// <summary>
    /// Create order
    /// </summary>
    /// <param name="request"></param>
    /// <returns>Order</returns>
    [HttpPost("create")]
    public async Task<IActionResult> CreateOrder([FromForm]CreateOrderDto request)
    {
        var requestResult = await _mediator.Send(
            _mapper.Map<CreateOrderCommand>(request));

        return requestResult.Match(
            result => Ok(_mapper.Map<OrderResponse>(result)),
            errors => Problem(errors));
    }
}