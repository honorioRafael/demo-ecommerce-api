using ErrorOr;
using FluentValidation;
using MediatR;
using System.Reflection;

namespace ECommerce.Application.Behaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : IErrorOr
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_validators.Any())
        {
            return await next();
        }

        var context = new ValidationContext<TRequest>(request);

        var validationResults = await Task.WhenAll(
            _validators.Select(v => v.ValidateAsync(context, cancellationToken)));

        var errors = validationResults
            .Where(r => r.Errors.Any())
            .SelectMany(r => r.Errors)
            .Select(f => Error.Validation(
                code: f.PropertyName,
                description: f.ErrorMessage))
            .ToList();

        if (errors.Any())
        {
            return CreateValidationResult<TResponse>(errors);
        }

        return await next();
    }

    private static TResponse CreateValidationResult<TResult>(List<Error> errors)
        where TResult : IErrorOr
    {
        return (TResponse)typeof(TResult)
            .GetMethod(
                name: nameof(ErrorOr<object>.From),
                bindingAttr: BindingFlags.Static | BindingFlags.Public,
                types: new[] { typeof(List<Error>) })!
            .Invoke(null, new object[] { errors })!;
    }
}
