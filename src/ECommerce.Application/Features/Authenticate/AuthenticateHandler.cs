using ECommerce.Application.Commands.Authenticate;
using ECommerce.Application.DTOs.Authenticate;
using ECommerce.Application.Interfaces.Jwt;
using ECommerce.Application.Interfaces.Security;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces.Repositories;
using ECommerce.Domain.ValueObjects;
using ErrorOr;
using MediatR;

namespace ECommerce.Application.Features.Authenticate;

public class AuthenticateHandler(IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtProvider jwtProvider) : IRequestHandler<AuthenticateCommand, ErrorOr<AuthenticateDto>>
{
    public async Task<ErrorOr<AuthenticateDto>> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
    {
        User? user = await userRepository.GetByEmailAsync(new Email(request.Email));
        if (user == null)
            return Error.Unauthorized("User.InvalidCredentials", "Email ou senha inválidos");

        if (!passwordHasher.Verify(request.Password, user.PasswordHash))
            return Error.Unauthorized("User.InvalidCredentials", "Email ou senha inválidos");

        string token = jwtProvider.Generate(user.Id, request.Email, $"{user.FirstName} {user.LastName}");
        return new AuthenticateDto(token);
    }
}
