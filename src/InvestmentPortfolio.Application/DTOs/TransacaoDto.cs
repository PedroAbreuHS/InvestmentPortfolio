
using InvestmentPortfolio.Domain.Entities;
using InvestmentPortfolio.Domain.Enums;

namespace InvestmentPortfolio.Application.DTOs
{
    public class TransacaoDto
    {
        public required string Nome { get; set; } = null!;

        public required Guid PortfolioId { get; set; }
        public required Portfolio Portfolio { get; set; } = null!;

        public required Guid AtivoId { get; set; }
        public required Ativo Ativo { get; set; } = null!;

        public required TipoTransacao TipoTransacao { get; set; }
        public required int Quantidade { get; set; }
        public required decimal Preco { get; set; }
        
        public DateTime DataTransacao { get; set; } = DateTime.Now;
    }
}
