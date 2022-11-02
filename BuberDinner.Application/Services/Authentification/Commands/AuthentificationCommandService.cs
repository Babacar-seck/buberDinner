using BuberDinner.Application.Common.Interfaces.Authentification;
using BuberDinner.Application.Services.Authentification.Common;
using BuberDinner.Application.Services.Persistence;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Services.Authentification.Commands;



public class AuthentificationCommandService : IAuthentificationCommandService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthentificationCommandService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }
    public AuthentificationResult Register(string firstName, string lastName, string email, string password)
    {
        //1. Validate The user doesn't exist
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            throw new Exception("User with given email already exists");
        }

        //2. Create user (generate unique ID) & Persist to DB

        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };
        _userRepository.Add(user);

        //3. Create JWT token

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthentificationResult(
            user,
            token
        );
    }
}
