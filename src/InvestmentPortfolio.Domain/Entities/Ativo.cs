
using FluentValidation.Results;
using InvestmentPortfolio.Domain.Enums;
using InvestmentPortfolio.Domain.Validations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvestmentPortfolio.Domain.Entities
{
    public class Ativo : EntityBase
    {
        public string Nome { get; set; } = null!;

        public TipoAtivo TipoAtivo { get; set; }
        public Codigo Codigo { get; set; }

        public Ativo()
        {
        }

        public Ativo(string nome, TipoAtivo tipoAtivo, Codigo codigo)
        {
            Nome = nome;
            TipoAtivo = tipoAtivo;
            Codigo = codigo;
        }

        public override ValidationResult IsValid()
        {
            ValidationResult = new AtivoValidations().Validate(this);
            return ValidationResult;
        }
    }
}
