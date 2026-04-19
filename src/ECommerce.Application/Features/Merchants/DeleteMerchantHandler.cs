using ECommerce.Application.Commands.Merchants;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces.Repositories;
using ErrorOr;
using MediatR;

namespace ECommerce.Application.Features.Merchants;

public class DeleteMerchantHandler(IMerchantRepository merchantRepository) : IRequestHandler<DeleteMerchantCommand, ErrorOr<Deleted>>
{
    public async Task<ErrorOr<Deleted>> Handle(DeleteMerchantCommand request, CancellationToken cancellationToken)
    {
        Merchant? merchant = await merchantRepository.GetByIdAsync(request.Id, cancellationToken);
        if (merchant is null)
            return Error.NotFound(code: "Merchant.NotFound", description: "Merchant not found.");

        merchantRepository.Delete(merchant);
        await merchantRepository.SaveChangesAsync(cancellationToken);

        return Result.Deleted;
    }
}
