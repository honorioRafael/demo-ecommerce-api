using ECommerce.Application.DTOs.Products;
using ErrorOr;
using MediatR;

namespace ECommerce.Application.Commands.Products;

public record UpdateProductCommand(
    Guid Id,
    string Name,
    string Description,
    decimal Price,
    decimal DiscountRate,
    int AvailableQuantity) : IRequest<ErrorOr<ProductDto>>;
