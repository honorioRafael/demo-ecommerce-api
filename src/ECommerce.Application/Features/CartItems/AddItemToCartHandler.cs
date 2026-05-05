using ECommerce.Application.Commands.CartItems;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces.Repositories;
using ErrorOr;
using MediatR;

namespace ECommerce.Application.Features.CartItems;

public class AddItemToCartHandler(IUnitOfWork unitOfWork, ICartItemRepository cartItemRepository, IUserRepository userRepository, IProductRepository productRepository) : IRequestHandler<AddItemToCartCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(AddItemToCartCommand request, CancellationToken cancellationToken)
    {
        User? relatedUser = await userRepository.GetByIdAsync(request.UserId, cancellationToken);
        if (relatedUser is null)
            return Error.NotFound(description: "Usuário não encontrado");

        Product? relatedProduct = await productRepository.GetByIdAsync(request.ProductId, cancellationToken);
        if (relatedProduct is null)
            return Error.NotFound(description: "Produto não encontrado");

        if (relatedProduct.AvailableQuantity < request.Quantity)
            return Error.Validation(description: "Quantidade solicitada excede a quantidade disponível");

        CartItem? cartItem = await cartItemRepository.GetByProductIdAsync(request.UserId, request.ProductId, cancellationToken);
        if (cartItem is null)
        {
            cartItem = new CartItem(request.UserId, request.ProductId, request.Quantity);
            await cartItemRepository.CreateAsync(cartItem, cancellationToken);
        }
        else
        {
            cartItem.AddQuantity(request.Quantity);
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success;
    }
}
