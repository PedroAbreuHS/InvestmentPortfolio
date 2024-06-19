using InvestmentPortfolio.Application.DTOs;
using InvestmentPortfolio.Domain.Entities;
using InvestmentPortfolio.Domain.Repositories;

namespace InvestmentPortfolio.Application.UseCases.PortfolioUseCases
{
    public class CadastrarPortfolioUseCase
    {
        private readonly IPortfolioRepository _portfolioRepository;

        public CadastrarPortfolioUseCase(IPortfolioRepository portfolioRepository)
        {
            _portfolioRepository = portfolioRepository;
        }

        public void Execute(PortfolioDto portfolioDto)
        {
            Portfolio portfolio = new(portfolioDto.Nome, portfolioDto.Descricao, portfolioDto.UsuarioId, portfolioDto.Usuario);

            _portfolioRepository.Adicionar(portfolio);
        }
    }
}
