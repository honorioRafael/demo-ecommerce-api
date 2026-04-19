using ECommerce.Application.Commands.Users;
using ECommerce.Domain.Enums;

namespace ECommerce.Api.Requests.Users;

public record CreateUserRequest(string Email, string Password, string FirstName, string LastName, string Nickname, Gender Gender, string? Cpf)
{
    public CreateUserCommand ConvertToCommand() => new CreateUserCommand(Email, Password, FirstName, LastName, Nickname, Gender, Cpf);
}