using ECommerce.Application.DTOs;
using ECommerce.Application.Queries;
using ECommerce.Domain.Interfaces.Repositories;
using ErrorOr;
using MediatR;

namespace ECommerce.Application.Features;

public class GetUserByIdHandler(IUserRepository userRepository) : IRequestHandler<GetUserByIdQuery, ErrorOr<UserDto>>
{
    public async Task<ErrorOr<UserDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(request.Id, cancellationToken);

        if (user is null)
        {
            return Error.NotFound(code: "User.NotFound", description: "User not found.");
        }

        return (UserDto)user;
    }
}
