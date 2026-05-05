using ECommerce.Application.Commands.CartItems;
using FluentValidation;

namespace ECommerce.Application.Validators.CartItems;

public class AddItemToCartCommandValidator : AbstractValidator<AddItemToCartCommand>
{
    public AddItemToCartCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("O UserId é obrigatório.");

        RuleFor(x => x.ProductId)
            .NotEmpty().WithMessage("O ProductId é obrigatório.");

        RuleFor(x => x.Quantity)
            .GreaterThan(0).WithMessage("A quantidade deve ser maior que 0");
    }
}
