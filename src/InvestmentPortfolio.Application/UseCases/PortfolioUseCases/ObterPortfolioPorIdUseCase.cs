
using InvestmentPortfolio.Domain.Entities;
using InvestmentPortfolio.Domain.Repositories;

namespace InvestmentPortfolio.Application.UseCases.PortfolioUseCases
{
    public class ObterPortfolioPorIdUseCase
    {
        private readonly IPortfolioRepository _portfolioRepository;

        public ObterPortfolioPorIdUseCase(IPortfolioRepository portfolioRepository)
        {
            _portfolioRepository = portfolioRepository;
        }

        public async Task<Portfolio?> Execute(Guid id)
        {
            Portfolio? portfolio = await _portfolioRepository.ObterPorId(id);

            return portfolio;
        }
    }
}
