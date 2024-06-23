
using InvestmentPortfolio.Domain.Entities;
using InvestmentPortfolio.Domain.Repositories;

namespace InvestmentPortfolio.Application.UseCases.TransacaoUseCases
{
    public class RemoverTransacaoUseCase
    {
        private readonly ITransacaoRepository _transacaoRepository;

        public RemoverTransacaoUseCase(ITransacaoRepository transacaoRepository)
        {
            _transacaoRepository = transacaoRepository;
        }

        public async Task Execute(Guid id)
        {
            Transacao? transacao = await _transacaoRepository.ObterPorId(id);

            if (transacao == null) throw new ArgumentException("Não há registro com o id informado.");

            await _transacaoRepository.Remover(id);
        }
    }
}
