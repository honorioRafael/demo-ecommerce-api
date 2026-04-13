using ECommerce.Application.Commands.Users;
using ECommerce.Application.DTOs.Users;
using ECommerce.Application.Interfaces.Security;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces.Repositories;
using ECommerce.Domain.ValueObjects;
using ErrorOr;
using MediatR;

namespace ECommerce.Application.Features.Users;

public class CreateUserHandler(IUserRepository userRepository, IPasswordHasher passwordHasher) : IRequestHandler<CreateUserCommand, ErrorOr<UserDto>>
{
    public async Task<ErrorOr<UserDto>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        User? existingUserByEmail = await userRepository.GetByEmailAsync(new Email(request.Email), cancellationToken);
        if (existingUserByEmail != null)
            return Error.Conflict("User.Email", "Já existe um usuário com esse email");

        string passwordHash = passwordHasher.Hash(request.Password);

        User user = new User(new Email(request.Email), passwordHash, request.FirstName, request.LastName, request.Nickname, request.Gender, request.Cpf != null ? new Cpf(request.Cpf) : null);

        await userRepository.CreateAsync(user, cancellationToken);
        await userRepository.SaveChangesAsync(cancellationToken);

        return (UserDto)user;
    }
}
