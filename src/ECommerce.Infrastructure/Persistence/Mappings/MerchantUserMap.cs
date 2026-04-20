using ECommerce.Domain.Entities;
using ECommerce.Infrastructure.Persistence.Mappings.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Persistence.Mappings;

public class MerchantUserMap : BaseMap<MerchantUser>
{
    public override void Configure(EntityTypeBuilder<MerchantUser> builder)
    {
        base.Configure(builder);
        builder.ToTable("merchant_user");

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
