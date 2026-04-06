using ECommerce.Application.DTOs;
using ErrorOr;
using MediatR;

namespace ECommerce.Application.Queries;

public record GetUserByEmailQuery(string Email) : IRequest<ErrorOr<UserDto>>;
