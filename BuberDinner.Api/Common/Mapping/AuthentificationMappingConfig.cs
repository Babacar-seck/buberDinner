using BuberDinner.Application.Authentification.Commands.Register;
using BuberDinner.Application.Authentification.Commom;
using BuberDinner.Application.Authentification.Queries.Login;
using BuberDinner.Contracts.Authentification;
using Mapster;

namespace BuberDinner.Api.Common.Mapping;

public class AuthentificationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        //Mapping <From  , to >

        config.NewConfig<RegisterRequest, RegisterCommand>();

        config.NewConfig<LoginRequest, LoginQuery>();
        config.NewConfig<AuthentificationResult, AuthentificationResponse>()
                            .Map(dest => dest, src => src.User);

        // config.NewConfig<AuthentificationResult, AuthentificationResponse>()
        //       .Map(dest => dest.Token, src => src.Token)
        //       .Map(dest => dest, src => src.User);
    }
}