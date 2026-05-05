using ECommerce.Application.DTOs.Products;
using ErrorOr;
using MediatR;

namespace ECommerce.Application.Queries.Products;

public record GetAllProductsQuery(int PageIndex = 0, int PageSize = 10) : IRequest<ErrorOr<List<ProductDto>>>;
