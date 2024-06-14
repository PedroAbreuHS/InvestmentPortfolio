
using InvestmentPortfolio.Domain.Enums;

namespace InvestmentPortfolio.Domain.Entities
{
    public class Transacao : EntityBase
    {
        public string Nome { get; set; } = null!;

        public Guid PortfolioId { get; set; }
        public Portfolio Portfolio { get; set; } = null!;

        public Guid AtivoId { get; set; }
        public Ativo Ativo { get; set; } = null!;

        public TipoTransacao TipoTransacao { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
        public DateTime DataTransacao { get; set; } = DateTime.Now;

        public Transacao()
        {
        }

        public Transacao(string nome, Guid portfolioId, Portfolio portfolio, Guid ativoId, Ativo ativo, TipoTransacao tipoTransacao, int quantidade, decimal preco, DateTime dataTransacao)
        {
            Nome = nome;
            PortfolioId = portfolioId;
            Portfolio = portfolio;
            AtivoId = ativoId;
            Ativo = ativo;
            TipoTransacao = tipoTransacao;
            Quantidade = quantidade;
            Preco = preco;
            DataTransacao = dataTransacao;
        }
    }
}
