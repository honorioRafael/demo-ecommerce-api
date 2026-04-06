using ECommerce.Application.DTOs;
using ECommerce.Application.Queries;
using ECommerce.Domain.Interfaces.Repositories;
using ECommerce.Domain.ValueObjects;
using ErrorOr;
using MediatR;

namespace ECommerce.Application.Features;

public class GetUserByEmailHandler(IUserRepository userRepository) : IRequestHandler<GetUserByEmailQuery, ErrorOr<UserDto>>
{
    public async Task<ErrorOr<UserDto>> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByEmailAsync(new Email(request.Email), cancellationToken);

        if (user is null)
        {
            return Error.NotFound(code: "User.NotFound", description: "User not found.");
        }

        return (UserDto)user;
    }
}
