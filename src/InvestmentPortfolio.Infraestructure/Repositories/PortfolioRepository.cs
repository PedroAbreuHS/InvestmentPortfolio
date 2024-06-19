
using InvestmentPortfolio.Domain.Entities;
using InvestmentPortfolio.Domain.Repositories;
using InvestmentPortfolio.Infraestructure.Data;

namespace InvestmentPortfolio.Infraestructure.Repositories
{
    public class PortfolioRepository : Repository<Portfolio>, IPortfolioRepository
    {
        public PortfolioRepository(AppDbContext Context) : base(Context)
        {
        }
    }
}
