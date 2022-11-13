using BuberDinner.Application.Authentification.Commands.Register;
using BuberDinner.Application.Authentification.Commom;
using BuberDinner.Application.Authentification.Queries.Login;
using BuberDinner.Contracts.Authentification;
using ErrorOr;
using MapsterMapper;
using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[Route("auth")]
public class AuthentificationController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper  _mapper;

    // Approach Without MediatR
    // private readonly IAuthentificationCommandService _authentificationCommandService;
    // private readonly IAuthentificationQueryService _authentificationQueryService;

    // public AuthentificationController(IAuthentificationCommandService authentificationCommandService,
    // IAuthentificationQueryService authentificationQueryService )
    // {
    //     _authentificationCommandService = authentificationCommandService;
    //     _authentificationQueryService  = authentificationQueryService;
    // }

    public AuthentificationController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        //Before Mapper
        //var  command =  new RegisterCommand(request.FirstName,request.LastName,request.Email,request.Password);
        var  command =  _mapper.Map<RegisterCommand>(request);

         ErrorOr<AuthentificationResult> authResult =  await _mediator.Send(command);

         return authResult.Match(
            authResult => Ok(_mapper.Map<AuthentificationResponse>(authResult)),
            errors => Problem(errors));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {   //Before Mapper
        //var query =  new LoginQuery(request.Email, request.Password);
        var query =  _mapper.Map<LoginQuery>(request);
        ErrorOr<AuthentificationResult> authResult =  await _mediator.Send(query);

         return authResult.Match(
            authResult => Ok(_mapper.Map<AuthentificationResponse>(authResult)),
            errors => Problem(errors));
    //errors  = la liste d'errors est présente dans le controller apiController
    }

    // private static AuthentificationResponse MapAuthResult(AuthentificationResult authResult)
    // {
    //     return new AuthentificationResponse(
    //             authResult.User.Id,
    //             authResult.User.FirstName,
    //             authResult.User.LastName,
    //             authResult.User.Email,
    //             authResult.Token
    //     );
    //}
}