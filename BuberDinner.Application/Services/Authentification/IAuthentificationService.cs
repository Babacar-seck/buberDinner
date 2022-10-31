using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Services.Authentification;

public interface IAuthentificationService
{
    AuthentificationResult Login(string email, string password);

    AuthentificationResult Register( string firstName, string lastName, string email, string password);
    IEnumerable<User> GetAllUsers();

}