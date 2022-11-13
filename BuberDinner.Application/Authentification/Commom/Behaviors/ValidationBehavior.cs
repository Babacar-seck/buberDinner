using ErrorOr;
using FluentValidation;
using MediatR;

namespace BuberDinner.Application.Authentification.Commom.Behaviors;
public class ValidationBehavior <TRequest, TResponse> :
            IPipelineBehavior<TRequest, TResponse>
            where TRequest : IRequest<TRequest>
            where TResponse : IErrorOr
{
    private readonly IValidator<TRequest>? _validator;

    public ValidationBehavior(IValidator<TRequest>? validator = null)
    {
        _validator = validator;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (_validator is null)
        {
            return await next();
        }
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (validationResult.IsValid)
        {
            return await next();
        }

        var errors = validationResult
            .Errors
            .ConvertAll(validationFailure => Error.Validation(
                validationFailure.PropertyName,
                validationFailure.ErrorMessage));
        //before the handler
        var result = await next();
        //after the handler

        // Not good use Dynamic
        return (dynamic)errors;
    }
}

#region //Methode Ciblée avec une prceision des parametres du IPipelineBehavior
/*public class ValidateRegisterCommandBehavior : IPipelineBehavior<RegisterCommand, ErrorOr<AuthentificationResult>>
{
    public readonly IValidator<RegisterCommand> _validator;

    public ValidateRegisterCommandBehavior(IValidator<RegisterCommand> validator)
    {
        _validator = validator;
    }

    public async Task<ErrorOr<AuthentificationResult>> Handle(
        RegisterCommand request,
        RequestHandlerDelegate<ErrorOr<AuthentificationResult>> next,
        CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (validationResult.IsValid)
        {
            return await next();
        }

        var errors = validationResult
            .Errors
            .ConvertAll(validationFailure => Error.Validation(
                validationFailure.PropertyName,
                validationFailure.ErrorMessage));
        //before the handler
        var result = await next();
        //after the handler

        return errors;
    }
}*/
#endregion
