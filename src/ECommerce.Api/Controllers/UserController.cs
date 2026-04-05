using ECommerce.Api.Requests;
using ECommerce.Application.Commands;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var result = await mediator.Send((CreateUserCommand)request, cancellationToken);

        return result.Match(
            Ok,
            HandleErrors
        );
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