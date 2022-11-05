using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Authentification.Commom;

public record AuthentificationResult(User User, string Token);