using FluentValidation;
using IdentityService.Application.Commands;

namespace IdentityService.Application.Validators;

public class LoginCommandValidator 
    : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(x => x.Login)
            .NotNull().WithMessage("Requisição não pode estar vazia.")
            .When(x => true);

        RuleFor(x => x.Login.Username)
            .NotEmpty().WithMessage("Requer um nome de usuário.")
            .When(x => true);

        RuleFor(x => x.Login.Password)
            .NotEmpty().WithMessage("Requer uma senha.")
            .MinimumLength(6).WithMessage("A senha deve ter pelo menos 6 caracteres.")
            .When(x => true);
    }
}