using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Services.Authentification;

public record AuthentificationResult(
    User User,
    string Token
);