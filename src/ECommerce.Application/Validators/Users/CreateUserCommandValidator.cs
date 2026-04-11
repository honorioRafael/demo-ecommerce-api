using ECommerce.Application.Commands.Users;
using FluentValidation;

namespace ECommerce.Application.Validators.Users;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("O Email é obrigatório")
            .EmailAddress().WithMessage("O formato do Email é inválido");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("A Senha é obrigatória")
            .MaximumLength(40).WithMessage("A Senha deve ter no máximo 40 caracteres");

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
            .NotEmpty().WithMessage("O Cpf é obrigatório")
            .Length(11).WithMessage("O Cpf deve ter 11 caracteres");
    }
}