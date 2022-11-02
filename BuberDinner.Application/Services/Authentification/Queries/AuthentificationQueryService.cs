using BuberDinner.Application.Common.Interfaces.Authentification;
using BuberDinner.Application.Services.Authentification.Common;
using BuberDinner.Application.Services.Persistence;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Services.Authentification.Queries;
public class AuthentificationQueryService : IAuthentificationQueryService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthentificationQueryService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public AuthentificationResult Login(string email, string password)
    {
        //1. Validate the user exists
        if (_userRepository.GetUserByEmail(email) is not User user)
        {
            throw new Exception("User with email does not exist. ");
        }

        //2.Valide the password is correct 
        if (user.Password != password)
        {
            throw new Exception("Invalid password. ");
        }

        //3. Create JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthentificationResult(
                   user,
                   token
               );
    }
}
