using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers.Base;

public class BaseController : ControllerBase
{
    protected readonly IMediator _mediator;

    public BaseController(IMediator mediator)
    {
        _mediator = mediator;
    }

    protected IActionResult MatchOk<T>(ErrorOr<T> result)
        where T : class
    {
        return result.Match(onValue: Ok, HandleErrors);
    }

    protected IActionResult HandleErrors(List<Error> errors)
    {
        var first = errors[0];

        var statusCode = first.Type switch
        {
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.Unauthorized => StatusCodes.Status401Unauthorized,
            ErrorType.Forbidden => StatusCodes.Status403Forbidden,
            _ => StatusCodes.Status500InternalServerError
        };

        return Problem(title: first.Code, detail: first.Description, statusCode: statusCode);
    }
}