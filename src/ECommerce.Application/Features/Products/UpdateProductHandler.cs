using ECommerce.Application.Commands.Products;
using ECommerce.Application.DTOs.Products;
using ECommerce.Domain.Interfaces.Repositories;
using ECommerce.Domain.ValueObjects;
using ErrorOr;
using MediatR;

namespace ECommerce.Application.Features.Products;

public class UpdateProductHandler(IProductRepository productRepository, IUnitOfWork unitOfWork) : IRequestHandler<UpdateProductCommand, ErrorOr<ProductDto>>
{
    public async Task<ErrorOr<ProductDto>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetByIdAsync(request.Id, cancellationToken);
        if (product is null)
            return Error.NotFound("Product.NotFound", "Produto não encontrado.");

        product.ChangeSellingData(
            request.Name,
            request.Description,
            new Price(request.Price),
            new DiscountRate(request.DiscountRate),
            request.AvailableQuantity);

        productRepository.Update(product);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return (ProductDto)product;
    }
}
