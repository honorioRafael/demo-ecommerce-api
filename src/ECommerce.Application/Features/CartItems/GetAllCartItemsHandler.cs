using ECommerce.Application.DTOs.CartItems;
using ECommerce.Application.Queries.CartItems;
using ECommerce.Domain.Interfaces.Repositories;
using ErrorOr;
using MediatR;

namespace ECommerce.Application.Features.CartItems;

internal class GetAllCartItemsHandler(ICartItemRepository cartitemRepository) : IRequestHandler<GetAllCartItemsQuery, ErrorOr<List<CartItemDto>>>
{
    public async Task<ErrorOr<List<CartItemDto>>> Handle(GetAllCartItemsQuery request, CancellationToken cancellationToken)
    {
        var cartitems = await cartitemRepository.GetAllAsync(request.PageIndex, request.PageSize, cancellationToken: cancellationToken);

        return cartitems.Select(m => (CartItemDto)m).ToList();
    }
}
