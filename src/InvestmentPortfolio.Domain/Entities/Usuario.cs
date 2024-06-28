using System.ComponentModel.DataAnnotations;

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
            ValidarEmail(email);
            ValidarSenha(senha);

            Id = Guid.NewGuid();
            Nome = nome;
            Email = email;
            Senha = BCrypt.Net.BCrypt.HashPassword(senha);
        }

        public void AtualizarInformacoes(string nome, string email, string senha)
        {
            Nome = nome;
            Email = email;

            if (!string.IsNullOrWhiteSpace(senha))
            {
                Senha = BCrypt.Net.BCrypt.HashPassword(senha);
            }
        }

        private void ValidarEmail(string email)
        {
            var validarEmail = new EmailAddressAttribute();
            if (!validarEmail.IsValid(email))
            {
                throw new ArgumentException("Email inválido!");
            }
        }

        private void ValidarSenha(string senha)
        {
            if (string.IsNullOrWhiteSpace(senha))
            {
                throw new ArgumentException("Senha não pode ser vazia ou nula.");
            }
        }

        public void ValidarSenhaConfirmacao(string senha, string confirmarSenha)
        {
            if (senha != confirmarSenha)
            {
                throw new ArgumentException("Senha confirmação diferente da senha informada");
            }
        }
    }

}
