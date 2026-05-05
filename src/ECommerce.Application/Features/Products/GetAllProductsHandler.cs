using ECommerce.Application.DTOs.Products;
using ECommerce.Application.Queries.Products;
using ECommerce.Domain.Interfaces.Repositories;
using ErrorOr;
using MediatR;

namespace ECommerce.Application.Features.Products;

public class GetAllProductsHandler(IProductRepository productRepository) : IRequestHandler<GetAllProductsQuery, ErrorOr<List<ProductDto>>>
{
    public async Task<ErrorOr<List<ProductDto>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await productRepository.GetAllAsync(request.PageIndex, request.PageSize, true, cancellationToken);
        return products.Select(p => (ProductDto)p).ToList();
    }
}
