using ECommerce.Application.DTOs.Products;
using ECommerce.Application.Queries.Products;
using ECommerce.Domain.Interfaces.Repositories;
using ErrorOr;
using MediatR;

namespace ECommerce.Application.Features.Products;

public class GetProductByIdHandler(IProductRepository productRepository) : IRequestHandler<GetProductByIdQuery, ErrorOr<ProductDto>>
{
    public async Task<ErrorOr<ProductDto>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetByIdAsync(request.Id, cancellationToken);
        if (product is null)
            return Error.NotFound("Product.NotFound", "Produto não encontrado.");

        return (ProductDto)product;
    }
}
