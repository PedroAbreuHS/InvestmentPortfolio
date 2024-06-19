
using InvestmentPortfolio.Domain.Entities;
using InvestmentPortfolio.Domain.Repositories;

namespace InvestmentPortfolio.Application.UseCases.AtivoUseCases
{
    public class ObterTodosAtivosUseCase
    {
        private readonly IAtivoRepository _ativoRepository;

        public ObterTodosAtivosUseCase(IAtivoRepository ativoRepository)
        {
            _ativoRepository = ativoRepository;
        }

        public async Task<List<Ativo>> Execute()
        {
            List<Ativo> ativos = await _ativoRepository.ObterTodos();

            return ativos;
        }
    }
}
