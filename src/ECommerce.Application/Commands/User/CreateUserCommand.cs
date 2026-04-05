using ECommerce.Application.DTOs;
using ECommerce.Domain.Enums;
using ErrorOr;
using MediatR;

namespace ECommerce.Application.Commands;

public record CreateUserCommand : IRequest<ErrorOr<UserDto>>
{
    public string Email { get; private set; }
    public string Password { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Nickname { get; private set; }
    public Gender Gender { get; private set; }
    public string? Cpf { get; private set; }

    public CreateUserCommand(string email, string password, string firstName, string lastName, string nickname, Gender gender, string? cpf)
    {
        Email = email;
        Password = password;
        FirstName = firstName;
        LastName = lastName;
        Nickname = nickname;
        Gender = gender;
        Cpf = cpf;
    }
}
