
using InvestmentPortfolio.Domain.Entities;
using InvestmentPortfolio.Domain.Repositories;

namespace InvestmentPortfolio.Application.UseCases.AtivoUseCases
{
    public class RemoverAtivoUseCase
    {
        private readonly IAtivoRepository _ativoRepository;

        public RemoverAtivoUseCase(IAtivoRepository ativoRepository)
        {
            _ativoRepository = ativoRepository;
        }

        public async Task Execute(Guid id)
        {
            Ativo? ativo = await _ativoRepository.ObterPorId(id);

            if (ativo == null) throw new ArgumentException("Não há registro com o id informado.");

            await _ativoRepository.Remover(id);
        }
    }
}
