using ECommerce.Application.DTOs;
using ErrorOr;
using MediatR;

namespace ECommerce.Application.Queries;

public record GetAllUsersQuery() : IRequest<ErrorOr<List<UserDto>>>;
