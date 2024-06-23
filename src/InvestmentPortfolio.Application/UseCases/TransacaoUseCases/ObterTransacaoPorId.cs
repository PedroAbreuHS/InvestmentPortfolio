
using InvestmentPortfolio.Domain.Entities;
using InvestmentPortfolio.Domain.Repositories;

namespace InvestmentPortfolio.Application.UseCases.TransacaoUseCases
{
    public class ObterTransacaoPorId
    {
        private readonly ITransacaoRepository _transacaoRepository;

        public ObterTransacaoPorId(ITransacaoRepository transacaoRepository)
        {
            _transacaoRepository = transacaoRepository;
        }

        public async Task<Transacao?> Execute (Guid id)
        {
            Transacao? transacao = await _transacaoRepository.ObterPorId (id);

            return transacao;
        }
    }
}
