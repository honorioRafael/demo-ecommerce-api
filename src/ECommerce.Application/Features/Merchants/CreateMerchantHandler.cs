using ECommerce.Application.Commands.Merchants;
using ECommerce.Application.DTOs.Merchants;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces.Repositories;
using ECommerce.Domain.ValueObjects;
using ErrorOr;
using MediatR;

namespace ECommerce.Application.Features.Merchants;

public class CreateMerchantHandler(IMerchantRepository merchantRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateMerchantCommand, ErrorOr<MerchantDto>>
{
    public async Task<ErrorOr<MerchantDto>> Handle(CreateMerchantCommand request, CancellationToken cancellationToken)
    {
        Merchant? existingMerchant = await merchantRepository.GetByCnpjAsync(new Cnpj(request.Cnpj), cancellationToken);
        if (existingMerchant is not null)
            return Error.Conflict("Merchant.Cnpj", "Já existe um merchant com esse CNPJ.");

        Merchant merchant = new Merchant(request.TradeName, request.LegalName, new Cnpj(request.Cnpj));
        merchant.AddUser(request.LoggedUserId);

        await merchantRepository.CreateAsync(merchant, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return (MerchantDto)merchant;
    }
}
