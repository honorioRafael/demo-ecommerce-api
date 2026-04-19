using ECommerce.Application.Commands.Merchants;
using ECommerce.Domain.ValueObjects;
using FluentValidation;

namespace ECommerce.Application.Validators.Merchants;

public class UpdateMerchantCommandValidator : AbstractValidator<UpdateMerchantCommand>
{
    public UpdateMerchantCommandValidator()
    {
        RuleFor(x => x.TradeName)
            .NotEmpty().WithMessage("O TradeName é obrigatório")
            .MaximumLength(100).WithMessage("O TradeName deve ter no máximo 100 caracteres");

        RuleFor(x => x.LegalName)
            .NotEmpty().WithMessage("O LegalName é obrigatório")
            .MaximumLength(200).WithMessage("O LegalName deve ter no máximo 200 caracteres");

        RuleFor(x => x.Cnpj)
            .NotEmpty().WithMessage("O CNPJ é obrigatório")
            .Length(14).WithMessage("O CNPJ deve ter exatamente 14 dígitos")
            .Matches("^[0-9]{14}$").WithMessage("O CNPJ deve conter apenas dígitos numéricos, sem máscara")
            .Must(Cnpj.IsValid).WithMessage("O CNPJ é matematicamente inválido");
    }
}
