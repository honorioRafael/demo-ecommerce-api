using ECommerce.Application.DTOs.Users;
using ErrorOr;
using MediatR;

namespace ECommerce.Application.Queries.Users;

public record GetAllUsersQuery(int PageIndex, int PageSize) : IRequest<ErrorOr<List<UserDto>>>;
