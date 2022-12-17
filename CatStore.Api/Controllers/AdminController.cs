using AutoMapper;
using CatStore.Application.Cats.Commands.CreateCat;
using CatStore.Application.Cats.Commands.DeleteCat;
using CatStore.Application.Cats.Commands.UpdateCat;
using CatStore.Application.Cats.Common;
using CatStore.Application.Common.Dtos.Cat;
using CatStore.Application.Common.Dtos.Users;
using CatStore.Application.UserManagement.Commands.DeleteUserCommand;
using CatStore.Application.UserManagement.Commands.UpdateUserCommand;
using CatStore.Application.UserManagement.Common;
using CatStore.Application.UserManagement.Queries.GetAllUsersQuery;
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
    public async Task<IActionResult> UpdateCat([FromForm] UpdateCatDto dto)
    {
        var requestResult = await _mediator.Send(_mapper.Map<UpdateCatCommand>(dto));
        
        return requestResult.Match(
            result => Ok(_mapper.Map<CatResponse>(result)),
            errors => Problem(errors));
    }
    
    
    /// <summary>
    /// Delete cat
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Cat.Id</returns>
    [HttpDelete("cat/delete/{id:guid}")]
    public async Task<IActionResult> DeleteCat(Guid id)
    {
        var requestResult = await _mediator.Send(new DeleteCatCommand() { Id = id });
        return requestResult.Match(
            result => Ok(_mapper.Map<CatResponse>(result)),
            errors => Problem(errors));
    }
    
    
    /// <summary>
    /// Create cat
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPost("cat/create")]
    public async Task<IActionResult> Create([FromForm] CreateCatDto dto)
    {
        var requestResult = await _mediator.Send(_mapper.Map<CreateCatCommand>(dto));
        
        return requestResult.Match(
            result => Ok(_mapper.Map<CatResponse>(result)),
            errors => Problem(errors));
    }
    

    [HttpGet("users")]
    public async Task<IActionResult> GetAllUsers()
    {
        var requestResult = await _mediator.Send(new GetAllUsersQuery());
        
        return requestResult.Match(
            result => Ok(result),
            errors => Problem(errors));
    }
    
    
    [HttpDelete("user/delete/{userId:guid}")]
    public async Task<IActionResult> DeleteUser(Guid userId)
    {
        var requestResult = await _mediator.Send(new DeleteUserCommand(){ UserId = userId});
        
        return requestResult.Match(
            result => Ok(result),
            errors => Problem(errors));
    }

    
    [HttpPut("user/update")]
    public async Task<IActionResult> UpdateUser([FromForm] UpdateUserDto dto)
    {
        var requestResult = await _mediator.Send(_mapper.Map<UpdateUserCommand>(dto));
        
        return requestResult.Match(
            result => Ok(_mapper.Map<UserResponse>(result)),
            errors => Problem(errors));
    }
    
}