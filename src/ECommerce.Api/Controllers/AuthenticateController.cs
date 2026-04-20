using ECommerce.Api.Controllers.Base;
using ECommerce.Api.Requests.Authenticate;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace ECommerce.Api.Controllers;

[Route("api/auth")]
public class AuthenticateController : BaseController
{
    public AuthenticateController(IMediator mediator) : base(mediator) { }

    [HttpPost("login")]
    [AllowAnonymous]
    [EnableRateLimiting("login")]
    public async Task<IActionResult> Authenticate(AuthenticateRequest request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(request.ConvertToCommand(), cancellationToken);
        return result.Match(
            Ok,
            HandleErrors
        );
    }
}
