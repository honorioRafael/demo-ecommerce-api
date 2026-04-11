using ECommerce.Application.Commands.Users;
using ECommerce.Application.DTOs.Users;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces.Repositories;
using ECommerce.Domain.ValueObjects;
using ErrorOr;
using MediatR;

namespace ECommerce.Application.Features.Users;

public class CreateUserHandler(IUserRepository userRepository) : IRequestHandler<CreateUserCommand, ErrorOr<UserDto>>
{
    public async Task<ErrorOr<UserDto>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        User user = new User(new Email(request.Email), request.Password, request.FirstName, request.LastName, request.Nickname, request.Gender, request.Cpf != null ? new Cpf(request.Cpf) : null);

        await userRepository.CreateAsync(user, cancellationToken);
        await userRepository.SaveChangesAsync(cancellationToken);

        return (UserDto)user;
    }
}
