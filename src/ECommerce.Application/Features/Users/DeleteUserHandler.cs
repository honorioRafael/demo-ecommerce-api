using ECommerce.Application.Commands.Users;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces.Repositories;
using ErrorOr;
using MediatR;

namespace ECommerce.Application.Features.Users;

public class DeleteUserHandler(IUserRepository userRepository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteUserCommand, ErrorOr<Deleted>>
{
    public async Task<ErrorOr<Deleted>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        User? user = await userRepository.GetByIdAsync(request.Id, cancellationToken);
        if (user is null)
            return Error.NotFound(code: "User.NotFound", description: "User not found.");

        user.MarkAsDeleted();
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Deleted;
    }
}
