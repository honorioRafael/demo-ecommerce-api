using ECommerce.Application.Commands.Products;

namespace ECommerce.Api.Requests.Products;

public record UpdateProductRequest(
    string Name,
    string Description,
    decimal Price,
    decimal DiscountRate,
    int AvailableQuantity)
{
    public UpdateProductCommand ConvertToCommand(Guid id) =>
        new UpdateProductCommand(
            id,
            Name,
            Description,
            Price,
            DiscountRate,
            AvailableQuantity);
}
