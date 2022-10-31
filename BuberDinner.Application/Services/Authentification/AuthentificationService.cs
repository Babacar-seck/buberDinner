using BuberDinner.Application.Common.Interfaces.Authentification;
using BuberDinner.Application.Services.Persistence;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Services.Authentification;



public class AuthentificationService : IAuthentificationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthentificationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public IEnumerable<User> GetAllUsers()
    {
        return _userRepository.GetAllUsers();

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
