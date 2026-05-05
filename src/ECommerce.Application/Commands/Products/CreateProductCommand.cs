using ECommerce.Application.DTOs.Products;
using ErrorOr;
using MediatR;

namespace ECommerce.Application.Commands.Products;

public record CreateProductCommand(
    string Name,
    string Description,
    Guid MerchantId,
    decimal Price,
    decimal DiscountRate,
    int AvailableQuantity) : IRequest<ErrorOr<ProductDto>>;
