using ECommerce.Application.DTOs;
using ErrorOr;
using MediatR;

namespace ECommerce.Application.Queries;

public record GetUserByIdQuery(Guid Id) : IRequest<ErrorOr<UserDto>>;
