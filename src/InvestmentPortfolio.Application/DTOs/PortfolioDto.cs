
using InvestmentPortfolio.Domain.Entities;

namespace InvestmentPortfolio.Application.DTOs
{
    public class PortfolioDto
    {
        public required string Nome { get; set; } = null!;

        public required string Descricao { get; set; } = null!;

        public required Guid UsuarioId { get; set; }

        public required UsuarioDto Usuario { get; set; } = null!;
    }
}
