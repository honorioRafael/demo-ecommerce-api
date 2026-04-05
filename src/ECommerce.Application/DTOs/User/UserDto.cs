using ECommerce.Domain.Entities;
using ECommerce.Domain.Enums;

namespace ECommerce.Application.DTOs;

public record UserDto(Guid Id, string Email, string FirstName, string LastName, string Nickname, Gender Gender, string? Cpf)
{
    public static implicit operator UserDto(User user)
    {
        return new UserDto(user.Id, user.Email.Value, user.FirstName, user.LastName, user.Nickname, user.Gender, user.Cpf?.Value);
    }
}