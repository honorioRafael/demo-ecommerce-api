using ECommerce.Application.Commands.CartItems;
using FluentValidation;

namespace ECommerce.Application.Validators.CartItems;

public class UpdateCartItemQuantityCommandValidator : AbstractValidator<UpdateCartItemQuantityCommand>
{
    public UpdateCartItemQuantityCommandValidator()
    {
        RuleFor(x => x.CartItemId)
            .NotEmpty().WithMessage("O CartItemId é obrigatório.");

        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("O UserId é obrigatório.");

        RuleFor(x => x.Quantity)
            .GreaterThanOrEqualTo(0).WithMessage("A quantidade deve ser maior or igual a 0.");
    }
}
