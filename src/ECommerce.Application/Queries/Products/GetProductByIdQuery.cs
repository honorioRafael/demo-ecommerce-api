using ECommerce.Application.DTOs.Products;
using ErrorOr;
using MediatR;

namespace ECommerce.Application.Queries.Products;

public record GetProductByIdQuery(Guid Id) : IRequest<ErrorOr<ProductDto>>;
