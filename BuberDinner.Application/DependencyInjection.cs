
using BuberDinner.Application.Services.Authentification;
using Microsoft.Extensions.DependencyInjection;

namespace BuberDinner.Application;

public static class DependencyInjection
{

    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthentificationService, AuthentificationService>();
        
        return services;

    }
}