using ECommerce.Application.DTOs;
using ECommerce.Application.Queries;
using ECommerce.Domain.Interfaces.Repositories;
using ErrorOr;
using MediatR;

namespace ECommerce.Application.Features;

public class GetAllUsersHandler(IUserRepository userRepository) : IRequestHandler<GetAllUsersQuery, ErrorOr<List<UserDto>>>
{
    public async Task<ErrorOr<List<UserDto>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await userRepository.GetAllAsync(request.PageIndex, request.PageSize, cancellationToken: cancellationToken);

        return users.Select(u => (UserDto)u).ToList();
    }
}
