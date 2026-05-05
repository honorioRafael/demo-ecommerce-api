using ECommerce.Application.Commands.Products;
using FluentValidation;

namespace ECommerce.Application.Validators.Products;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("O nome é obrigatório.")
            .MaximumLength(200).WithMessage("O nome deve ter no máximo 200 caracteres.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("A descrição é obrigatória.")
            .MaximumLength(1000).WithMessage("A descrição deve ter no máximo 1000 caracteres.");

        RuleFor(x => x.MerchantId)
            .NotEmpty().WithMessage("O MerchantId é obrigatório.");

        RuleFor(x => x.Price)
            .GreaterThanOrEqualTo(0).WithMessage("O preço deve ser maior ou igual a zero.");

        RuleFor(x => x.DiscountRate)
            .InclusiveBetween(0, 100).WithMessage("O percentual de desconto deve estar entre 0 e 100.");

        RuleFor(x => x.AvailableQuantity)
            .GreaterThanOrEqualTo(0).WithMessage("A quantidade disponível deve ser maior ou igual a zero.");
    }
}
