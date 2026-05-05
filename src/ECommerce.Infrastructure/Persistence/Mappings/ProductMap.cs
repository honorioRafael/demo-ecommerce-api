using ECommerce.Domain.Entities;
using ECommerce.Domain.ValueObjects;
using ECommerce.Infrastructure.Persistence.Mappings.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Persistence.Mappings;

public class ProductMap : BaseMap<Product>
{
    public override void Configure(EntityTypeBuilder<Product> builder)
    {
        base.Configure(builder);
        builder.ToTable("product");

        builder.Property(x => x.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasMaxLength(1000)
            .IsRequired();

        builder.Property(x => x.Price)
            .HasPrecision(18, 2)
            .IsRequired()
            .HasConversion(
                v => v.Value,
                v => new Price(v));

        builder.Property(x => x.FinalPrice)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(x => x.DiscountRate)
            .HasPrecision(5, 2)
            .IsRequired()
            .HasConversion(
                v => v.Value,
                v => new DiscountRate(v));

        builder.Property(x => x.Rating)
            .IsRequired()
            .HasConversion(
                v => v.Value,
                v => new Rating(v));

        builder.Property(x => x.SoldNumber)
            .IsRequired();

        builder.Property(x => x.AvailableQuantity)
            .IsRequired();

        builder.HasOne(x => x.Merchant)
            .WithMany()
            .HasForeignKey(x => x.MerchantId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
