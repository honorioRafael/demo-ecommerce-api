using ECommerce.Application.DTOs.Users;
using ErrorOr;
using MediatR;

namespace ECommerce.Application.Queries.Users;

public record GetUserByIdQuery(Guid Id) : IRequest<ErrorOr<UserDto>>;
