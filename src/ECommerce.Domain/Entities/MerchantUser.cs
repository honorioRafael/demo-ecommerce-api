using ECommerce.Domain.Entities.Base;

namespace ECommerce.Domain.Entities;

public class MerchantUser : BaseEntity
{
    public Guid MerchantId { get; private set; }
    public Guid UserId { get; private set; }

    #region Navigation Properties
    public Merchant Merchant { get; private set; }
    public User User { get; private set; }
    #endregion

    protected MerchantUser() { }

    public MerchantUser(Guid merchantId, Guid userId)
    {
        MerchantId = merchantId;
        UserId = userId;
    }
}