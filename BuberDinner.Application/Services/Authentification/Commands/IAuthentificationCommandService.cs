using BuberDinner.Application.Services.Authentification.Common;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Services.Authentification.Commands;

public interface IAuthentificationCommandService
{
    // Register is a Command (Does something but not  return result) Method Adding the user in th DB
    AuthentificationResult Register( string firstName, string lastName, string email, string password);
}