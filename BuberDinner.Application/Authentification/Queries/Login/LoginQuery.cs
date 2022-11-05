using BuberDinner.Application.Authentification.Commom;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Authentification.Queries.Login;

public record LoginQuery(
    string Email,
    string Password) : IRequest<ErrorOr<AuthentificationResult>>;
