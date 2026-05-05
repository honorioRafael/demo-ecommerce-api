using ECommerce.Application.Commands.Products;
using ECommerce.Application.DTOs.Products;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces.Repositories;
using ECommerce.Domain.ValueObjects;
using ErrorOr;
using MediatR;

namespace ECommerce.Application.Features.Products;

public class CreateProductHandler(IProductRepository productRepository, IUnitOfWork unitOfWork, IMerchantRepository merchantRepository) : IRequestHandler<CreateProductCommand, ErrorOr<ProductDto>>
{
    public async Task<ErrorOr<ProductDto>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        Merchant? relatedMerchant = await merchantRepository.GetByIdAsync(request.MerchantId);
        if(relatedMerchant is null)
            return Error.NotFound(description: "Nenhum Merchant foi encontrado com o ID fornecido.");

        var product = new Product(
            request.Name,
            request.Description,
            request.MerchantId,
            new Price(request.Price),
            new DiscountRate(request.DiscountRate),
            request.AvailableQuantity);

        await productRepository.CreateAsync(product, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return (ProductDto)product;
    }
}
