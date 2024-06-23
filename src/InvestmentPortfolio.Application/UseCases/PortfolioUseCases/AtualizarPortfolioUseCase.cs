
using InvestmentPortfolio.Application.DTOs;
using InvestmentPortfolio.Domain.Entities;
using InvestmentPortfolio.Domain.Repositories;

namespace InvestmentPortfolio.Application.UseCases.PortfolioUseCases
{
    public class AtualizarPortfolioUseCase
    {
        private readonly IPortfolioRepository _portfolioRepository;

        public AtualizarPortfolioUseCase(IPortfolioRepository portfolioRepository)
        {
            _portfolioRepository = portfolioRepository;
        }

        public async Task Execute(Guid id, PortfolioDto portfolioDto)
        {
            Portfolio? portfolio = await _portfolioRepository.ObterPorId(id);

            if (portfolio == null) throw new ArgumentException("Não há registro com o id informado.");

            portfolio.Id = id;
            portfolio.Nome = portfolioDto.Nome;
            portfolio.Usuario = portfolioDto.Usuario;
            portfolio.Descricao = portfolioDto.Descricao;
            portfolio.UsuarioId = portfolioDto.UsuarioId;

            await _portfolioRepository.Atualizar(portfolio);
        }
    }
}
