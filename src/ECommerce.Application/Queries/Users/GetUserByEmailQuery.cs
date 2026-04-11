using ECommerce.Application.DTOs.Users;
using ErrorOr;
using MediatR;

namespace ECommerce.Application.Queries.Users;

public record GetUserByEmailQuery(string Email) : IRequest<ErrorOr<UserDto>>;
