using ECommerce.Application.Commands.Merchants;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces.Repositories;
using ECommerce.Domain.ValueObjects;
using ErrorOr;
using MediatR;

namespace ECommerce.Application.Features.Merchants;

public class UpdateMerchantHandler(IMerchantRepository merchantRepository) : IRequestHandler<UpdateMerchantCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(UpdateMerchantCommand request, CancellationToken cancellationToken)
    {
        Merchant? merchant = await merchantRepository.GetByIdAsync(request.Id, cancellationToken);
        if (merchant is null)
            return Error.NotFound(code: "Merchant.NotFound", description: "Merchant not found.");

        merchant.Update(request.TradeName, request.LegalName, new Cnpj(request.Cnpj));
        merchantRepository.Update(merchant);
        await merchantRepository.SaveChangesAsync(cancellationToken);

        return Result.Success;
    }
}
