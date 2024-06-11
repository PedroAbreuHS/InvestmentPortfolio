namespace InvestmentPortfolio.Domain.Entities
{
    public class Usuario : EntityBase
    {
        public string Nome { get; set; } = null!;

        public string Email { get; set; } = null!;
        public string Senha { get; set; } = null!;

       
    }
}
