using ECommerce.Application.Commands.Addresses;
using ECommerce.Domain.ValueObjects;
using FluentValidation;

namespace ECommerce.Application.Validators.Addresses;

public class CreateAddressCommandValidator : AbstractValidator<CreateAddressCommand>
{
    public CreateAddressCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("O Name é obrigatório")
            .MaximumLength(100).WithMessage("O Name deve ter no máximo 100 caracteres");

        RuleFor(x => x.Street)
            .NotEmpty().WithMessage("O Street é obrigatório")
            .MaximumLength(150).WithMessage("O Street deve ter no máximo 150 caracteres");

        RuleFor(x => x.Number)
            .NotEmpty().WithMessage("O Number é obrigatório")
            .MaximumLength(10).WithMessage("O Number deve ter no máximo 10 caracteres");

        RuleFor(x => x.Complement)
            .MaximumLength(100).WithMessage("O Complement deve ter no máximo 100 caracteres")
            .When(x => !string.IsNullOrEmpty(x.Complement));

        RuleFor(x => x.Neighborhood)
            .NotEmpty().WithMessage("O Neighborhood é obrigatório")
            .MaximumLength(100).WithMessage("O Neighborhood deve ter no máximo 100 caracteres");

        RuleFor(x => x.City)
            .NotEmpty().WithMessage("O City é obrigatório")
            .MaximumLength(100).WithMessage("O City deve ter no máximo 100 caracteres");

        RuleFor(x => x.State)
            .NotEmpty().WithMessage("O State é obrigatório")
            .Length(2).WithMessage("O State deve ter exatamente 2 caracteres (UF)")
            .Matches("^[A-Z]{2}$").WithMessage("O State deve ser a UF em letras maiúsculas (ex: SP, RJ)");

        RuleFor(x => x.Country)
            .NotEmpty().WithMessage("O Country é obrigatório")
            .Length(2).WithMessage("O Country deve ter exatamente 2 caracteres (ISO 3166-1 alpha-2)")
            .Matches("^[A-Z]{2}$").WithMessage("O Country deve ser o código ISO em letras maiúsculas (ex: BR, US)");

        RuleFor(x => x.ZipCode)
            .NotEmpty().WithMessage("O ZipCode é obrigatório")
            .Length(8).WithMessage("O ZipCode deve ter exatamente 8 dígitos")
            .Matches("^[0-9]{8}$").WithMessage("O ZipCode deve conter apenas dígitos numéricos")
            .Must(ZipCode.IsValid).WithMessage("O ZipCode é inválido");
    }
}
