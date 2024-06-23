
using InvestmentPortfolio.Domain.Entities;
using InvestmentPortfolio.Domain.Repositories;

namespace InvestmentPortfolio.Application.UseCases.TransacaoUseCases
{
    public class ObterTodasTransacoesUseCase
    {
        private readonly ITransacaoRepository _transacaoRepository;

        public ObterTodasTransacoesUseCase(ITransacaoRepository transacaoRepository)
        {
            _transacaoRepository = transacaoRepository;
        }

        public async Task<List<Transacao>> Execute()
        {
            List<Transacao> transacoes = await _transacaoRepository.ObterTodos();

            return transacoes;
        }
    }
}
