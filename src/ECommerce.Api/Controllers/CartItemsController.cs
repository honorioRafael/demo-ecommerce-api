using ECommerce.Api.Controllers.Base;
using ECommerce.Api.Requests.CartItems;
using ECommerce.Application.Commands.CartItems;
using ECommerce.Application.Interfaces.Security;
using ECommerce.Application.Queries.CartItems;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers;

public class CartItemsController : BaseController
{
    private readonly ICurrentUserService _currentUserService;

    public CartItemsController(IMediator mediator, ICurrentUserService currentUserService) : base(mediator)
    {
        _currentUserService = currentUserService;
    }

    #region Create
    [HttpPost]
    public async Task<IActionResult> AddItemToCart(AddItemToCartRequest request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(request.ConvertToCommand(_currentUserService.UserId!.Value), cancellationToken);
        return result.Match(
            _ => Ok(),
            HandleErrors
        );
    }
    #endregion

    #region Read
    [HttpGet]
    public async Task<IActionResult> GetAll(int pageIndex, int pageSize, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetAllCartItemsQuery(pageIndex, pageSize), cancellationToken);
        return MatchOk(result);
    }
    #endregion

    #region Update
    [HttpPut("{id:guid}/quantity")]
    public async Task<IActionResult> UpdateQuantity(Guid id, UpdateCartItemQuantityRequest request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new UpdateCartItemQuantityCommand(id, _currentUserService.UserId!.Value, request.Quantity), cancellationToken);
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
        var result = await _mediator.Send(new RemoveCartItemCommand(id, _currentUserService.UserId!.Value), cancellationToken);
        return result.Match(
            _ => NoContent(),
            HandleErrors
        );
    }
    #endregion
}
