using FluentValidation;
using InvestmentPortfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentPortfolio.Domain.Validations
{
    public class UsuarioValidations : AbstractValidator<Usuario>
    {
        public UsuarioValidations()
        {
            RuleFor(u => u.Nome)
                .NotEmpty().WithMessage("O nome do usuário não pode ser vazio.");

            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("O email do usuário não pode ser vazio.")
                .EmailAddress().WithMessage("O email do usuário deve ser válido.");

            RuleFor(u => u.Senha)
                .NotEmpty().WithMessage("A senha do usuário não pode ser vazia.")
                .MinimumLength(6).WithMessage("A senha do usuário deve ter pelo menos 6 caracteres.");
        }
    }

}
