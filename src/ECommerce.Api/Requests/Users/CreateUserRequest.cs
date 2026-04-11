using ECommerce.Application.Commands.Users;
using ECommerce.Domain.Enums;

namespace ECommerce.Api.Requests.Users;

public class CreateUserRequest
{
    public string Email { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public string Nickname { get; init; } = string.Empty;
    public Gender Gender { get; init; }
    public string? Cpf { get; init; }

    public static implicit operator CreateUserCommand(CreateUserRequest request) => new CreateUserCommand(request.Email, request.Password, request.FirstName, request.LastName, request.Nickname, request.Gender, request.Cpf);
}
