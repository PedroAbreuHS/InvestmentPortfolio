using FluentValidation;
using InvestmentPortfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentPortfolio.Domain.Validations
{
    public class PortfolioValidations : AbstractValidator<Portfolio>
    {
        public PortfolioValidations() {
            RuleFor(p => p.Id)
               .NotEmpty();

            RuleFor(p => p.Descricao)
                .NotEmpty()
                .NotNull();

            RuleFor(p => p.Nome)
                .NotEmpty()
                .NotNull();

            RuleFor(p => p.Usuario)
                .NotNull();
        }
    }
}
