using ECommerce.Application.Commands.Authenticate;

namespace ECommerce.Api.Requests.Authenticate;

public record AuthenticateRequest
{
    public string Email { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;

    public static implicit operator AuthenticateCommand(AuthenticateRequest request) => new AuthenticateCommand(request.Email, request.Password);
};