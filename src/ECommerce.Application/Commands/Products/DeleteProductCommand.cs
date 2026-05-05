using ErrorOr;
using MediatR;

namespace ECommerce.Application.Commands.Products;

public record DeleteProductCommand(Guid Id) : IRequest<ErrorOr<Deleted>>;
