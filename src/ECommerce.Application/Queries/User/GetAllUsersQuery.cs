using ECommerce.Application.DTOs;
using ErrorOr;
using MediatR;

namespace ECommerce.Application.Queries;

public record GetAllUsersQuery(int PageIndex, int PageSize) : IRequest<ErrorOr<List<UserDto>>>;
