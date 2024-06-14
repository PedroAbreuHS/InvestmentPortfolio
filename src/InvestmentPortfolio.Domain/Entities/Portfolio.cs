
namespace InvestmentPortfolio.Domain.Entities
{
    public class Portfolio : EntityBase
    {
        public string Nome { get; set; } = null!;

        public string Descricao { get; set; } = null!;

        public Guid UsuarioId { get; set; }

        public Usuario Usuario { get; set; } = null!;

        public Portfolio()
        {
        }

        public Portfolio(string nome, string descricao, Guid usuarioId, Usuario usuario)
        {
            Nome = nome;
            Descricao = descricao;
            UsuarioId = usuarioId;
            Usuario = usuario;
        }
    }
}
