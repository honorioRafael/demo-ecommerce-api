using ECommerce.Domain.Entities.Base;
using ECommerce.Domain.Exceptions;
using ECommerce.Domain.ValueObjects;

namespace ECommerce.Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public Guid MerchantId { get; private set; }
    public Price Price { get; private set; } = null!;
    public decimal FinalPrice { get; private set; }
    public DiscountRate DiscountRate { get; private set; } = null!;
    public Rating Rating { get; private set; } = null!;
    public int SoldNumber { get; private set; }
    public int AvailableQuantity { get; private set; }

    #region Navigation Properties
    public Merchant Merchant { get; private set; } = null!;
    #endregion

    protected Product() { }

    public Product(string name, string description, Guid merchantId, Price price, DiscountRate discountRate, int availableQuantity)
    {
        Name = name;
        Description = description;
        MerchantId = merchantId;
        Price = price;
        DiscountRate = discountRate;
        AvailableQuantity = availableQuantity;
        Rating = new Rating(0);

        ApplyDiscount();
    }

    public void ChangeSellingData(string name, string description, Price price, DiscountRate discountRate, int availableQuantity)
    {
        Name = name;
        Description = description;
        Price = price;
        DiscountRate = discountRate;
        AvailableQuantity = availableQuantity;

        ApplyDiscount();
    }

    public void ApplyDiscount()
    {
        FinalPrice = Price.Value - DiscountRate.CalculateAmount(Price.Value);
        if(FinalPrice < 0)
            throw new DomainException("O preço final não pode ser negativo.");
    }

    public void Rate(Rating rating)
    {
        Rating = rating;
    }

    public void RegisterSale(int quantity)
    {
        if (quantity <= 0)
            throw new DomainException("A quantidade vendida deve ser maior que zero.");

        if (AvailableQuantity < quantity)
            throw new DomainException("Estoque insuficiente para realizar a venda.");

        SoldNumber += quantity;
        AvailableQuantity -= quantity;
    }
}
