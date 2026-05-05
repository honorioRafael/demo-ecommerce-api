using ECommerce.Application.Commands.CartItems;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces.Repositories;
using ErrorOr;
using MediatR;

namespace ECommerce.Application.Features.CartItems;

public class UpdateCartItemQuantityHandler(IUnitOfWork unitOfWork, ICartItemRepository cartItemRepository, IProductRepository productRepository) : IRequestHandler<UpdateCartItemQuantityCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(UpdateCartItemQuantityCommand request, CancellationToken cancellationToken)
    {
        CartItem? cartItem = await cartItemRepository.GetByIdAsync(request.CartItemId, cancellationToken);
        if (cartItem is null)
            return Error.NotFound("CartItem.NotFound", "Item do carrinho não encontrado.");

        if (cartItem.UserId != request.UserId)
            return Error.Forbidden("CartItem.Forbidden", "O item do carrinho não pertence ao usuário logado.");

        if (request.Quantity > 0)
        {
            Product product = (await productRepository.GetByIdAsync(cartItem.ProductId, cancellationToken))!;
            if (product.AvailableQuantity < request.Quantity)
                return Error.Validation("CartItem.InvalidQuantity", "Quantidade solicitada excede a quantidade disponível.");

            cartItem.ChangeQuantity(request.Quantity);
            cartItemRepository.Update(cartItem);
        }
        else
        {
            cartItemRepository.Delete(cartItem);
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success;
    }
}
