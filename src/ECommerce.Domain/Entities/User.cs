using ECommerce.Domain.Entities.Base;
using ECommerce.Domain.Enums;
using ECommerce.Domain.ValueObjects;

namespace ECommerce.Domain.Entities;

public class User : BaseEntity<User>
{
    public Email Email { get; private set; } = null!;
    public string PasswordHash { get; private set; } = null!;
    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public string Nickname { get; private set; } = null!;
    public Gender Gender { get; private set; }
    public Cpf? Cpf { get; private set; }

    protected User() { }

    public User(Email email, string passwordHash, string firstName, string lastName, string nickname, Gender gender, Cpf? cpf)
    {
        Email = email;
        PasswordHash = passwordHash;
        FirstName = firstName;
        LastName = lastName;
        Nickname = nickname;
        Gender = gender;
        Cpf = cpf;
    }

    public void ChangeEmail(Email email)
    {
        Email = email;
    }

    public void UpdateProfile(string firstName, string lastName, string nickname)
    {
        FirstName = firstName;
        LastName = lastName;
        Nickname = nickname;
    }
}