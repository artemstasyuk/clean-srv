using AutoMapper;
using CatStore.Application.Dtos.Auth;
using CatStore.Application.MediaR.Authentication.Commands.Register;
using CatStore.Application.MediaR.Authentication.Queries.Login;
using CatStore.Domain.Common.Errors;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CatStore.Api.Controllers;

[Route("/auth")]
[AllowAnonymous]
public class AuthController : ApiController
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    
    public AuthController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }
    
    /// <summary>
    /// Register
    /// </summary>
    /// <param name="registerDto">Register dto</param>
    /// <returns></returns>
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromForm]RegisterDto registerDto)
    {
        var command = _mapper.Map<RegisterCommand>(registerDto); 
        var registerReuslt = await _mediator.Send(command);

        return registerReuslt.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors));
    }
    
    /// <summary>
    /// Login
    /// </summary>
    /// <param name="loginDto">Login dto</param>
    /// <returns></returns>
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromForm]LoginDto loginDto)
    {
        var query = _mapper.Map<LoginQuery>(loginDto);
        var loginResult = await _mediator.Send(query);
        
        if (loginResult.IsError && loginResult.FirstError == Errors.Authentication.InvalidCredentials)
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized, 
                title: loginResult.FirstError.Description);
        
        return loginResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors));
    }
}