
using InvestmentPortfolio.Domain.Entities;
using InvestmentPortfolio.Domain.Repositories;

namespace InvestmentPortfolio.Application.UseCases.AtivoUseCases
{
    public class ObterAtivoPorIdUseCase
    {
        private readonly IAtivoRepository _ativoRepository;

        public ObterAtivoPorIdUseCase(IAtivoRepository ativoRepository)
        {
            _ativoRepository = ativoRepository;
        }

        public async Task<Ativo?> Execute(Guid id) 
        {
            Ativo? ativo = await _ativoRepository.ObterPorId(id);

            return ativo;
        }
    }
}
