using BuberDinner.Application.Services.Authentification;
using BuberDinner.Application.Services.Authentification.Commands;
using BuberDinner.Application.Services.Authentification.Queries;
using BuberDinner.Contracts.Authentification;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthentificationController : ControllerBase
{
    private readonly IAuthentificationCommandService _authentificationCommandService;
    private readonly IAuthentificationQueryService _authentificationQueryService;

    public AuthentificationController(IAuthentificationCommandService authentificationCommandService,
    IAuthentificationQueryService authentificationQueryService )
    {
        _authentificationCommandService = authentificationCommandService;
        _authentificationQueryService  = authentificationQueryService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var auhtResult = _authentificationCommandService.Register(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password
        );

        var response = new AuthentificationResponse(
                    auhtResult.User.Id,
                    auhtResult.User.FirstName,
                    auhtResult.User.LastName,
                    auhtResult.User.Email,
                    auhtResult.Token
                );

        return Ok(response);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var auhtResult = _authentificationQueryService.Login(
            request.Email,
            request.Password
        );

        var response = new AuthentificationResponse(
                    auhtResult.User.Id,
                    auhtResult.User.FirstName,
                    auhtResult.User.LastName,
                    auhtResult.User.Email,
                    auhtResult.Token
                );

        return Ok(response);
    }
}