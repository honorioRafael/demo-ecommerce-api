using ECommerce.Application.DTOs.Users;
using ECommerce.Domain.Enums;
using ErrorOr;
using MediatR;

namespace ECommerce.Application.Commands.Users;

public record CreateUserCommand(string Email, string Password, string FirstName, string LastName, string Nickname, Gender Gender, string? Cpf) : IRequest<ErrorOr<UserDto>>;