
using InvestmentPortfolio.Application.DTOs;
using InvestmentPortfolio.Domain.Entities;
using InvestmentPortfolio.Domain.Repositories;

namespace InvestmentPortfolio.Application.UseCases.TransacaoUseCases
{
    public class AtualizarTransacaoUseCase
    {
        private readonly ITransacaoRepository _transacaoRepository;

        public AtualizarTransacaoUseCase(ITransacaoRepository transacaoRepository)
        {
            _transacaoRepository = transacaoRepository;
        }

        public async Task<Transacao?> Execute(Guid id, TransacaoDto transacaoDto)
        {
            Transacao? transacao = await _transacaoRepository.ObterPorId(id);

            if (transacao == null) throw new ArgumentException("Não há registro com o id informado.");

            transacao.Nome = transacaoDto.Nome;
            transacao.PortfolioId = transacaoDto.PortfolioId;
            transacao.Portfolio = transacaoDto.Portfolio;
            transacao.AtivoId = transacaoDto.AtivoId;
            transacao.Ativo = transacaoDto.Ativo;
            transacao.TipoTransacao = transacaoDto.TipoTransacao;
            transacao.Quantidade = transacaoDto.Quantidade;
            transacao.Preco = transacaoDto.Preco;

            await _transacaoRepository.Atualizar(transacao);
        }
    }
}
