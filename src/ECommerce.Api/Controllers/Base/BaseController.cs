using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers.Base;

[Authorize]
[ApiController]
[Route("api/[controller]")]
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

        if (first.Type == ErrorType.Validation)
        {
            var validationErrors = errors
                .Select(e => new { field = e.Code, message = e.Description });

            return BadRequest(new
            {
                title = "Validation Error",
                status = StatusCodes.Status400BadRequest,
                errors = validationErrors
            });
        }

        var statusCode = first.Type switch
        {
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.Unauthorized => StatusCodes.Status401Unauthorized,
            ErrorType.Forbidden => StatusCodes.Status403Forbidden,
            _ => StatusCodes.Status500InternalServerError
        };

        return Problem(title: first.Code, detail: first.Description, statusCode: statusCode);
    }
}
