using System.Reflection;
using BuberDinner.Application.Authentification.Commands.Register;
using BuberDinner.Application.Authentification.Commom;
using BuberDinner.Application.Authentification.Commom.Behaviors;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BuberDinner.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // services.AddScoped<IAuthentificationCommandService, AuthentificationCommandService>();
        // services.AddScoped<IAuthentificationQueryService, AuthentificationQueryService>();
        services.AddMediatR(typeof(DependencyInjection).Assembly);

        // Add Formy Pipeline
        // services.AddScoped<
        //     IPipelineBehavior<RegisterCommand, ErrorOr<AuthentificationResult>>,
        //     ValidationBehavior>();
        services.AddScoped(
            typeof(IPipelineBehavior<,>),typeof(ValidationBehavior<,>));
        // FLUENVALIDATOR Implement
        //services.AddScoped<IValidator<RegisterCommand>, RegisterCommandValidator>();

        // After Add Package FluentValidatior.AspNetCore
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return services;
    }
}