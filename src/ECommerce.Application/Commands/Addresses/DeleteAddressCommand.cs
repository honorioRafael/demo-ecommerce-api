using ErrorOr;
using MediatR;

namespace ECommerce.Application.Commands.Addresses;

public record DeleteAddressCommand(Guid Id) : IRequest<ErrorOr<Deleted>>;
