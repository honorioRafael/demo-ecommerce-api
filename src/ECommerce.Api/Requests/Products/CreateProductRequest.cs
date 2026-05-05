using ECommerce.Application.Commands.Products;

namespace ECommerce.Api.Requests.Products;

public record CreateProductRequest(
    string Name,
    string Description,
    Guid MerchantId,
    decimal Price,
    decimal DiscountRate,
    int AvailableQuantity)
{
    public CreateProductCommand ConvertToCommand() =>
        new CreateProductCommand(
            Name,
            Description,
            MerchantId,
            Price,
            DiscountRate,
            AvailableQuantity);
}
