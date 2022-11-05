using BuberDinner.Application.Authentification.Commands.Register;
using BuberDinner.Application.Authentification.Commom;
using BuberDinner.Application.Authentification.Queries.Login;
using BuberDinner.Contracts.Authentification;
using ErrorOr;
using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[Route("auth")]
public class AuthentificationController : ApiController
{
    private readonly ISender _mediator;

    // Approach Without MediatR
    // private readonly IAuthentificationCommandService _authentificationCommandService;
    // private readonly IAuthentificationQueryService _authentificationQueryService;

    // public AuthentificationController(IAuthentificationCommandService authentificationCommandService,
    // IAuthentificationQueryService authentificationQueryService )
    // {
    //     _authentificationCommandService = authentificationCommandService;
    //     _authentificationQueryService  = authentificationQueryService;
    // }

    public AuthentificationController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var  command =  new RegisterCommand(request.FirstName,request.LastName,request.Email,request.Password);

         ErrorOr<AuthentificationResult> authResult =  await _mediator.Send(command);

         return authResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors));

        // var response = new AuthentificationResponse(
        //             auhtResult.User.Id,
        //             auhtResult.User.FirstName,
        //             auhtResult.User.LastName,
        //             auhtResult.User.Email,
        //             auhtResult.Token
        //         );

        // return Ok(response);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query =  new LoginQuery(request.Email, request.Password);
        ErrorOr<AuthentificationResult> authResult =  await _mediator.Send(query);

         return authResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors));

        // var auhtResult = _authentificationQueryService.Login(
        //     request.Email,
        //     request.Password
        // );
        // var response = new AuthentificationResponse(
        //             auhtResult.User.Id,
        //             auhtResult.User.FirstName,
        //             auhtResult.User.LastName,
        //             auhtResult.User.Email,
        //             auhtResult.Token
        //         );

        //return Ok(response);
    }

    private static AuthentificationResult MapAuthResult(AuthentificationResult authResult)
    {
        return authResult;
    }
}