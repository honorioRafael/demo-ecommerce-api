using ECommerce.Application.Commands.Users;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces.Repositories;
using ECommerce.Domain.ValueObjects;
using ErrorOr;
using MediatR;

namespace ECommerce.Application.Features.Users;

public class UpdateUserHandler(IUserRepository userRepository) : IRequestHandler<UpdateUserCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        User? user = await userRepository.GetByIdAsync(request.Id, cancellationToken);
        if (user is null)
            return Error.NotFound(code: "User.NotFound", description: "User not found.");

        user.Update(request.FirstName, request.LastName, request.Nickname, request.Gender, Cpf.TryParse(request.Cpf));
        userRepository.Update(user);
        await userRepository.SaveChangesAsync(cancellationToken);

        return Result.Success;
    }
}