using ECommerce.Application.Commands.CartItems;
using FluentValidation;

namespace ECommerce.Application.Validators.CartItems;

public class RemoveCartItemCommandValidator : AbstractValidator<RemoveCartItemCommand>
{
    public RemoveCartItemCommandValidator()
    {
        RuleFor(x => x.CartItemId)
            .NotEmpty().WithMessage("O CartItemId é obrigatório.");

        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("O UserId é obrigatório.");
    }
}
