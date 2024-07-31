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

        public bool Execute(PortfolioDto portfolioDto)
        {
            Portfolio portfolio = new Portfolio (
                portfolioDto.Nome, 
                portfolioDto.Descricao, 
                portfolioDto.UsuarioId,
                new Usuario(
                    portfolioDto.Usuario.Nome,
                    portfolioDto.Usuario.Email,
                    portfolioDto.Usuario.Senha
                ));

            _portfolioRepository.Adicionar(portfolio);
            return true;
        }
    }
}
