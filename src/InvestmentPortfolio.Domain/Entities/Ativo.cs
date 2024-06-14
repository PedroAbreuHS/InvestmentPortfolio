
using InvestmentPortfolio.Domain.Enums;

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
    }
}
