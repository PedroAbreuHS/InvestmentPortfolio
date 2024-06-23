
using InvestmentPortfolio.Domain.Entities;
using InvestmentPortfolio.Domain.Repositories;

namespace InvestmentPortfolio.Application.UseCases.PortfolioUseCases
{
    public class RemoverPortfolioUseCase
    {
        private readonly IPortfolioRepository _portfolioRepository;

        public RemoverPortfolioUseCase(IPortfolioRepository portfolioRepository)
        {
            _portfolioRepository = portfolioRepository;
        }

        public async Task Execute(Guid id)
        {
            Portfolio? portfolio = await _portfolioRepository.ObterPorId(id);

            if (portfolio == null) throw new ArgumentException("Não há registro com o id informado.");

            await _portfolioRepository.Remover(id);
        }
    }
}
