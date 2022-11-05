using BuberDinner.Application.Authentification.Commom;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Authentification.Commands.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password) : IRequest<ErrorOr<AuthentificationResult>>;