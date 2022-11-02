using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Services.Authentification.Common;

public record AuthentificationResult(
    User User,
    string Token
);