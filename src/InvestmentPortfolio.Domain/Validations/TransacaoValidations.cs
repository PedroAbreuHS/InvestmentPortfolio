using FluentValidation;
using InvestmentPortfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentPortfolio.Domain.Validations
{
    public class TransacaoValidations : AbstractValidator<Transacao>
    {
        public TransacaoValidations()
        {
            RuleFor(t => t.Nome)
                .NotEmpty().WithMessage("O nome da transação não pode ser vazio.");

            RuleFor(t => t.PortfolioId)
                .NotEmpty().WithMessage("O ID do portfólio não pode ser vazio.");

            RuleFor(t => t.Portfolio)
                .NotNull().WithMessage("O portfólio não pode ser nulo.");

            RuleFor(t => t.AtivoId)
                .NotEmpty().WithMessage("O ID do ativo não pode ser vazio.");

            RuleFor(t => t.Ativo)
                .NotNull().WithMessage("O ativo não pode ser nulo.");

            RuleFor(t => t.TipoTransacao)
                .IsInEnum().WithMessage("O tipo de transação deve ser válido.");

            RuleFor(t => t.Quantidade)
                .GreaterThan(0).WithMessage("A quantidade deve ser maior que zero.");

            RuleFor(t => t.Preco)
                .GreaterThan(0).WithMessage("O preço deve ser maior que zero.");

            RuleFor(t => t.DataTransacao)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("A data da transação não pode ser no futuro.");
        }
    }

}
