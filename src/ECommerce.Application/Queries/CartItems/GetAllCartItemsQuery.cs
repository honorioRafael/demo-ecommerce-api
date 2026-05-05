using ECommerce.Application.DTOs.CartItems;
using ErrorOr;
using MediatR;

namespace ECommerce.Application.Queries.CartItems;

public record GetAllCartItemsQuery(int PageIndex, int PageSize) : IRequest<ErrorOr<List<CartItemDto>>>;
