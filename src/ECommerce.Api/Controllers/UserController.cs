using ECommerce.Api.Controllers.Base;
using ECommerce.Api.Requests.Users;
using ECommerce.Application.Commands.Users;
using ECommerce.Application.Queries.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : BaseController
{
    public UserController(IMediator mediator) : base(mediator) { }

    [HttpPost]
    public async Task<IActionResult> Create(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send((CreateUserCommand)request, cancellationToken);
        return result.Match(
            value => CreatedAtAction(nameof(GetById), new { id = result.Value.Id }, result.Value),
            HandleErrors
        );
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetUserByIdQuery(id), cancellationToken);
        return MatchOk(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(int pageIndex, int pageSize, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetAllUsersQuery(pageIndex, pageSize), cancellationToken);
        return MatchOk(result);
    }

    [HttpGet("email/{email}")]
    public async Task<IActionResult> GetByEmail(string email, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetUserByEmailQuery(email), cancellationToken);
        return MatchOk(result);
    }
}