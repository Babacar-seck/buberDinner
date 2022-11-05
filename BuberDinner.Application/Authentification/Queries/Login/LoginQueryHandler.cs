using BuberDinner.Application.Common.Interfaces.Authentification;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Authentification.Commom;
using BuberDinner.Domain.Entities;
using BuberDinner.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Authentification.Queries.Login;
public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthentificationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthentificationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        //1. Validate the user exists
        if (_userRepository.GetUserByEmail(query.Email) is not User user)
        {
            return Errors.Authentification.InvalidCredential;
        }

        //2.Valide the password is correct 
        if (user.Password != query.Password)
        {
            return Errors.Authentification.InvalidCredential;
        }

        //3. Create JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthentificationResult(
                   user,
                   token
               );throw new NotImplementedException();
    }
}
