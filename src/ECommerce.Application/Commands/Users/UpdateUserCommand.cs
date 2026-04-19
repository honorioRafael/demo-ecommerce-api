using ECommerce.Domain.Enums;
using ErrorOr;
using MediatR;

namespace ECommerce.Application.Commands.Users;

public record UpdateUserCommand(Guid Id, string FirstName, string LastName, string Nickname, Gender Gender, string? Cpf) : IRequest<ErrorOr<Success>>;