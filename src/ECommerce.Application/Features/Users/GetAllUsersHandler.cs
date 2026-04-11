using ECommerce.Application.DTOs.Users;
using ECommerce.Application.Queries.Users;
using ECommerce.Domain.Interfaces.Repositories;
using ErrorOr;
using MediatR;

namespace ECommerce.Application.Features.Users;

public class GetAllUsersHandler(IUserRepository userRepository) : IRequestHandler<GetAllUsersQuery, ErrorOr<List<UserDto>>>
{
    public async Task<ErrorOr<List<UserDto>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await userRepository.GetAllAsync(request.PageIndex, request.PageSize, cancellationToken: cancellationToken);

        return users.Select(u => (UserDto)u).ToList();
    }
}
