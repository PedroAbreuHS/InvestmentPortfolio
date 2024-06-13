
namespace InvestmentPortfolio.Domain.Entities
{
    public class EntityBase
    {
        public Guid Id { get; set; }

        protected EntityBase()
        {
            Guid Id = Guid.NewGuid();
        }
    }
}
