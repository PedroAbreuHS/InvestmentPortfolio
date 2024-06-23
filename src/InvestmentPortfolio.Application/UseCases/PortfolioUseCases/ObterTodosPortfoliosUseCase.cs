
using InvestmentPortfolio.Domain.Entities;
using InvestmentPortfolio.Domain.Repositories;

namespace InvestmentPortfolio.Application.UseCases.PortfolioUseCases
{
    public class ObterTodosPortfoliosUseCase
    {
        private readonly IPortfolioRepository _portfolioRepository;

        public ObterTodosPortfoliosUseCase(IPortfolioRepository portfolioRepository)
        {
            _portfolioRepository = portfolioRepository;
        }

        public async Task<List<Portfolio>> Execute()
        {
            List<Portfolio> portfolios = await _portfolioRepository.ObterTodos();

            return portfolios;
        }
    }
}
