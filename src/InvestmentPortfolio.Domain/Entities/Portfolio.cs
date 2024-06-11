
namespace InvestmentPortfolio.Domain.Entities
{
    public class Portfolio : EntityBase
    {
        public string Nome { get; set; } = null!;

        public string Descricao { get; set; } = null!;

        public Guid UsuarioId { get; set; }

        public Usuario Usuario { get; set; } = null!;
    }
}
