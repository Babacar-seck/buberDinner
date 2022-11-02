using BuberDinner.Application.Services.Authentification.Common;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Services.Authentification.Queries;

public interface IAuthentificationQueryService
{
    //Register is a Query (return a result but does not Change the State) Method Adding the user in th DB
    AuthentificationResult Login(string email, string password);
}