using ECommerce.Application.Commands.Users;
using FluentValidation;

namespace ECommerce.Application.Validators.Users;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("O FirstName é obrigatório")
            .MaximumLength(50).WithMessage("O FirstName deve ter no máximo 50 caracteres");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("O LastName é obrigatório")
            .MaximumLength(100).WithMessage("O LastName deve ter no máximo 100 caracteres");

        RuleFor(x => x.Nickname)
            .NotEmpty().WithMessage("O Nickname é obrigatório")
            .MaximumLength(50).WithMessage("O Nickname deve ter no máximo 50 caracteres");

        RuleFor(x => x.Gender)
            .IsInEnum();

        RuleFor(x => x.Cpf)
            .Length(11).WithMessage("O Cpf deve ter 11 caracteres")
            .When(x => !string.IsNullOrEmpty(x.Cpf));
    }
}