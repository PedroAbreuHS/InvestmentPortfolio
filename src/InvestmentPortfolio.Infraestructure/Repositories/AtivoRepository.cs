
using InvestmentPortfolio.Domain.Entities;
using InvestmentPortfolio.Domain.Repositories;
using InvestmentPortfolio.Infraestructure.Data;

namespace InvestmentPortfolio.Infraestructure.Repositories
{
    public class AtivoRepository : Repository<Ativo>, IAtivoRepository
    {
        public AtivoRepository(AppDbContext Context) : base(Context)
        {
        }
    }
}
