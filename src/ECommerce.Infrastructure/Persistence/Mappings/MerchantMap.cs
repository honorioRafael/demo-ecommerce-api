using ECommerce.Domain.Entities;
using ECommerce.Domain.ValueObjects;
using ECommerce.Infrastructure.Persistence.Mappings.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Persistence.Mappings;

public class MerchantMap : BaseMap<Merchant>
{
    public override void Configure(EntityTypeBuilder<Merchant> builder)
    {
        base.Configure(builder);
        builder.ToTable("merchant");

        builder.Property(x => x.TradeName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.LegalName)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.Cnpj)
            .HasMaxLength(14)
            .IsRequired()
            .HasConversion(
                v => v.Value,
                v => new Cnpj(v));

        builder.HasIndex(nameof(Merchant.Cnpj))
            .IsUnique();
    }
}
