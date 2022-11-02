
using BuberDinner.Application.Services.Authentification;
using BuberDinner.Application.Services.Authentification.Commands;
using BuberDinner.Application.Services.Authentification.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace BuberDinner.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthentificationCommandService, AuthentificationCommandService>();
        services.AddScoped<IAuthentificationQueryService, AuthentificationQueryService>();
        return services;
    }
}