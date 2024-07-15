using FluentValidation;
using InvestmentPortfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentPortfolio.Domain.Validations
{
    public class AtivoValidations : AbstractValidator<Ativo>
    {
        public AtivoValidations()
        {
            RuleFor(a => a.Nome)
                .NotEmpty().WithMessage("O nome do ativo é obrigatório.")
                .Length(2, 150).WithMessage("O nome do ativo deve ter entre 2 e 150 caracteres.");

            RuleFor(a => a.TipoAtivo)
                .IsInEnum().WithMessage("Tipo de ativo inválido.");

            RuleFor(a => a.Codigo)
                .IsInEnum().WithMessage("O código do ativo é obrigatório.");
        }
    }
}
