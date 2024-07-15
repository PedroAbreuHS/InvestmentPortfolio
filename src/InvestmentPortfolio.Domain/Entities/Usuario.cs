using FluentValidation.Results;
using InvestmentPortfolio.Domain.Validations;

namespace InvestmentPortfolio.Domain.Entities
{
    public class Usuario : EntityBase
    {
        public string Nome { get; set; } = null!;

        public string Email { get; set; } = null!;
        public string Senha { get; set; } = null!;

        public Usuario()
        {
        }

        public Usuario(string nome, string email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = BCrypt.Net.BCrypt.HashPassword(senha);
        }

        public override ValidationResult IsValid()
        {
            ValidationResult = new UsuarioValidations().Validate(this);
            return ValidationResult;
        }
    }
}
