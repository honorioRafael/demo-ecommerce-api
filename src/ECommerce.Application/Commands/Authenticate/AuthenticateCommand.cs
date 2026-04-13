using ECommerce.Application.DTOs.Authenticate;
using ErrorOr;
using MediatR;

namespace ECommerce.Application.Commands.Authenticate;

public record AuthenticateCommand(string Email, string Password) : IRequest<ErrorOr<AuthenticateDto>>;