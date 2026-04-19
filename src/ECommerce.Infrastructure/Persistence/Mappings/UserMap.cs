using ECommerce.Domain.Entities;
using ECommerce.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ECommerce.Infrastructure.Persistence.Mappings;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("user");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.PasswordHash)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(x => x.FirstName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.LastName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Nickname)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.Gender)
            .HasConversion<int>();

        builder.Property(x => x.Email)
            .HasMaxLength(100)
            .HasConversion(
                v => v.Value,
                v => new Email(v));

        builder.HasIndex(x => x.Email)
            .IsUnique();

        var cpfConverter = new ValueConverter<Cpf?, string?>(
            v => v == null ? null : v.Value,
            v => v == null ? null : new Cpf(v));

        builder.Property(x => x.Cpf)
            .IsRequired(false)
            .HasMaxLength(11)
            .HasConversion(cpfConverter);

        builder.HasIndex(nameof(User.Cpf))
            .IsUnique();
    }
}
