using ECommerce.Application.Commands.Merchants;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces.Repositories;
using ErrorOr;
using MediatR;

namespace ECommerce.Application.Features.Merchants;

public class AddUserToMerchantHandler(IMerchantRepository merchantRepository, IUserRepository userRepository, IUnitOfWork unitOfWork) : IRequestHandler<AddUserToMerchantCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(AddUserToMerchantCommand request, CancellationToken cancellationToken)
    {
        Merchant? merchant = await merchantRepository.GetByIdAsync(request.MerchantId);
        if (merchant is null)
            return Error.NotFound("Merchant.NotFound", "Merchant not found.");

        User? user = await userRepository.GetByIdAsync(request.UserId);
        if (user is null)
            return Error.NotFound("User.NotFound", "User not found.");

        bool userAlreadyExists = await merchantRepository.UserExistsAsync(request.MerchantId, request.UserId, cancellationToken);
        if (userAlreadyExists)
            return Error.Conflict("User.AlreadyExists", "Já existe vinculo entre esse User e Merchant.");

        merchant.AddUser(user.Id);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success;
    }
}
