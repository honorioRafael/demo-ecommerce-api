using ErrorOr;
using MediatR;

namespace ECommerce.Application.Commands.Users;

public record DeleteUserCommand(Guid Id) : IRequest<ErrorOr<Deleted>>;
