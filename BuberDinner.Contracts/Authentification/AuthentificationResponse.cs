namespace BuberDinner.Contracts.Authentification;

public record AuthentificationResponse(
    Guid Guid,
    string FirstName,
    string LastName,
    string Email,
    string Token
    );