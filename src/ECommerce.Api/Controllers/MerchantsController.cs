using ECommerce.Api.Controllers.Base;
using ECommerce.Api.Requests.Merchants;
using ECommerce.Application.Commands.Merchants;
using ECommerce.Application.Interfaces.Security;
using ECommerce.Application.Queries.Merchants;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers;

public class MerchantsController : BaseController
{
    public MerchantsController(IMediator mediator) : base(mediator) { }

    #region Create
    [HttpPost]
    public async Task<IActionResult> Create(CreateMerchantRequest request, CancellationToken cancellationToken, ICurrentUserService currentUserService)
    {
        Guid loggedUserId = currentUserService.UserId!.Value;
        var result = await _mediator.Send(request.ConvertToCommand(loggedUserId), cancellationToken);
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
        var result = await _mediator.Send(new GetMerchantByIdQuery(id), cancellationToken);
        return MatchOk(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(int pageIndex, int pageSize, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetAllMerchantsQuery(pageIndex, pageSize), cancellationToken);
        return MatchOk(result);
    }

    [HttpGet("cnpj/{cnpj}")]
    public async Task<IActionResult> GetByCnpj(string cnpj, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetMerchantByCnpjQuery(cnpj), cancellationToken);
        return MatchOk(result);
    }
    #endregion

    #region Update
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, UpdateMerchantRequest request, CancellationToken cancellationToken)
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
        var result = await _mediator.Send(new DeleteMerchantCommand(id), cancellationToken);
        return result.Match(
            _ => NoContent(),
            HandleErrors
        );
    }
    #endregion

    #region User
    [HttpPost("{id:guid}/users/{userId:guid}")]
    public async Task<IActionResult> AddUserToMerchant(Guid id, Guid userId, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new AddUserToMerchantCommand(id, userId), cancellationToken);
        return result.Match(
            _ => NoContent(),
            HandleErrors
        );
    }
    #endregion
}
