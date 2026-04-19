using ECommerce.Domain.Entities;
using ECommerce.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Persistence.Mappings;

public class AddressMap : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("address");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Street)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(x => x.Number)
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(x => x.Complement)
            .HasMaxLength(100)
            .IsRequired(false);

        builder.Property(x => x.Neighborhood)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.City)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.State)
            .HasMaxLength(2)
            .IsRequired();

        builder.Property(x => x.Country)
            .HasMaxLength(2)
            .IsRequired();

        builder.Property(x => x.ZipCode)
            .HasMaxLength(8)
            .IsRequired()
            .HasConversion(
                v => v.Value,
                v => new ZipCode(v));
    }
}
