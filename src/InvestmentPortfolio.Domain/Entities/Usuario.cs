using FluentValidation.Results;
using InvestmentPortfolio.Domain.Validations;
using System.Security.Cryptography;
using System.Text;

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
            Senha = EncryptPassword(senha);
        }

        public override ValidationResult IsValid()
        {
            ValidationResult = new UsuarioValidations().Validate(this);
            return ValidationResult;
        }

        private string EncryptPassword(string password)
        {
            HashAlgorithm sha = new SHA1CryptoServiceProvider();

            byte[] encryptedPassword = sha.ComputeHash(Encoding.UTF8.GetBytes(password));

            StringBuilder stringBuilder = new StringBuilder();
            foreach (var caracter in encryptedPassword)
            {
                stringBuilder.Append(caracter.ToString("X2"));
            }

            return stringBuilder.ToString();
        }
    }
}
