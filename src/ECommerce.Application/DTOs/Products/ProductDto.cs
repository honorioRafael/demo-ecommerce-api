using ECommerce.Domain.Entities;

namespace ECommerce.Application.DTOs.Products;

public record ProductDto(
    Guid Id,
    string Name,
    string Description,
    Guid MerchantId,
    decimal Price,
    decimal FinalPrice,
    decimal DiscountRate,
    int Rating,
    int SoldNumber,
    int AvailableQuantity,
    DateTime CreatedAt,
    DateTime? UpdatedAt)
{
    public static implicit operator ProductDto(Product product)
    {
        return new ProductDto(
            product.Id,
            product.Name,
            product.Description,
            product.MerchantId,
            product.Price.Value,
            product.FinalPrice,
            product.DiscountRate.Value,
            product.Rating.Value,
            product.SoldNumber,
            product.AvailableQuantity,
            product.CreatedAt,
            product.UpdatedAt);
    }
}
