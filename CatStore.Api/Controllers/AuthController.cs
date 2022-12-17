using AutoMapper;
using CatStore.Application.Authentication.Commands.Register;
using CatStore.Application.Authentication.Queries.Login;
using CatStore.Application.Common.Dtos.Auth;
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
        var registerReuslt = await _mediator.Send(
            _mapper.Map<RegisterCommand>(registerDto));

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
        var loginResult = await _mediator.Send(
            _mapper.Map<LoginQuery>(loginDto));
        
        if (loginResult.IsError && loginResult.FirstError == Errors.Authentication.InvalidCredentials)
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized, 
                title: loginResult.FirstError.Description);
        
        return loginResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors));
    }
}