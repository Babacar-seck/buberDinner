using BuberDinner.Application.Services.Authentification;
using BuberDinner.Contracts.Authentification;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthentificationController : ControllerBase
{
    private readonly IAuthentificationService _authentificationService;

    public AuthentificationController(IAuthentificationService authentificationService)
    {
        _authentificationService = authentificationService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var auhtResult = _authentificationService.Register(
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
        var auhtResult = _authentificationService.Login(
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


    [HttpGet]
    public IActionResult GetAllUsers()
    {
        return Ok(_authentificationService.GetAllUsers());
    }
}