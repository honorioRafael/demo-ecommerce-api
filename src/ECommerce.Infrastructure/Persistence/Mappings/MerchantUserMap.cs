using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Persistence.Mappings;

public class MerchantUserMap : IEntityTypeConfiguration<MerchantUser>
{
    public void Configure(EntityTypeBuilder<MerchantUser> builder)
    {
        builder.ToTable("merchant_user");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.HasOne(x => x.Merchant)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.MerchantId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(nameof(MerchantUser.MerchantId), nameof(MerchantUser.UserId))
            .IsUnique();
    }
}
