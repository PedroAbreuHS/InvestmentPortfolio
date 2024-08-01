
using AutoMapper;
using InvestmentPortfolio.Application.DTOs;
using InvestmentPortfolio.Domain.Entities;
using InvestmentPortfolio.Domain.Repositories;

namespace InvestmentPortfolio.Application.UseCases.PortfolioUseCases
{
    public class ObterTodosPortfoliosUseCase
    {
        private readonly IPortfolioRepository _portfolioRepository;
        private readonly IMapper _mapper;

        public ObterTodosPortfoliosUseCase(IPortfolioRepository portfolioRepository, IMapper mapper)
        {
            _portfolioRepository = portfolioRepository;
            _mapper = mapper;
        }

        public async Task<List<PortfolioDto>> Execute()
        {
            List<Portfolio> portfolios = await _portfolioRepository.ObterTodos();
            
            return _mapper.Map<List<PortfolioDto>>(portfolios);
        }
    }
}
