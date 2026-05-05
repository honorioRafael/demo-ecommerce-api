using ECommerce.Application.DTOs.Products;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.DTOs.CartItems;

public record CartItemDto(Guid Id, Guid UserId, Guid ProductId, int Quantity, ProductDto? ProductDto)
{
    public static implicit operator CartItemDto(CartItem cartItem)
    {
        return new CartItemDto(
            cartItem.Id,
            cartItem.UserId,
            cartItem.ProductId,
            cartItem.Quantity,
            cartItem.Product);
    }
}
