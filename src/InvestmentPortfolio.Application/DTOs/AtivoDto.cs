
using InvestmentPortfolio.Domain.Enums;

namespace InvestmentPortfolio.Application.DTOs
{
    public class AtivoDto
    {
        public string Nome { get; set; } = null!;

        public required TipoAtivo TipoAtivo { get; set; } 
        public required Codigo Codigo { get; set; }
    }
}
