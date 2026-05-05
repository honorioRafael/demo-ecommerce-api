using ECommerce.Api.Controllers.Base;
using ECommerce.Api.Requests.Users;
using ECommerce.Application.Commands.Users;
using ECommerce.Application.Queries.Users;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers;

public class UsersController : BaseController
{
    public UsersController(IMediator mediator) : base(mediator) { }

    #region Create
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Create(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(request.ConvertToCommand(), cancellationToken);
        return result.Match(
            value => CreatedAtAction(nameof(GetById), new { id = result.Value.Id }, result.Value),
            HandleErrors
        );
    }
    #endregion

    #region Read
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
    #endregion

    #region Update
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, UpdateUserRequest request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(request.ConvertToCommand(id), cancellationToken);
        return result.Match(
            _ => NoContent(),
            HandleErrors
        );
    }
    #endregion

    #region Delete
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new DeleteUserCommand(id), cancellationToken);
        return result.Match(
            _ => NoContent(),
            HandleErrors
        );
    }
    #endregion
}
