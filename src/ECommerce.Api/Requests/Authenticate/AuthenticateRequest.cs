using ECommerce.Application.Commands.Authenticate;

namespace ECommerce.Api.Requests.Authenticate;

public record AuthenticateRequest
{
    public string Email { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;

    public AuthenticateCommand ConvertToCommand() => new AuthenticateCommand(Email, Password);
};