using ECommerce.Application.Commands.Users;
using ECommerce.Domain.Enums;

namespace ECommerce.Api.Requests.Users;

public record UpdateUserRequest(string FirstName, string LastName, string Nickname, Gender Gender, string? Cpf)
{
    public UpdateUserCommand ConvertToCommand(Guid id) => new UpdateUserCommand(id, FirstName, LastName, Nickname, Gender, Cpf);
}
