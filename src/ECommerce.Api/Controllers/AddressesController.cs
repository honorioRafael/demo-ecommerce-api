using ECommerce.Api.Controllers.Base;
using ECommerce.Api.Requests.Addresses;
using ECommerce.Application.Commands.Addresses;
using ECommerce.Application.Queries.Addresses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers;

public class AddressesController : BaseController
{
    public AddressesController(IMediator mediator) : base(mediator) { }

    #region Create
    [HttpPost]
    public async Task<IActionResult> Create(CreateAddressRequest request, CancellationToken cancellationToken)
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
        var result = await _mediator.Send(new GetAddressByIdQuery(id), cancellationToken);
        return MatchOk(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(int pageIndex, int pageSize, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetAllAddressesQuery(pageIndex, pageSize), cancellationToken);
        return MatchOk(result);
    }
    #endregion

    #region Update
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, UpdateAddressRequest request, CancellationToken cancellationToken)
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
        var result = await _mediator.Send(new DeleteAddressCommand(id), cancellationToken);
        return result.Match(
            _ => NoContent(),
            HandleErrors
        );
    }
    #endregion
}
