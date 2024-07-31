using InvestmentPortfolio.Application.DTOs;
using InvestmentPortfolio.Domain.Entities;
using InvestmentPortfolio.Domain.Repositories;

namespace InvestmentPortfolio.Application.UseCases.TransacaoUseCase
{
    public class CadastrarTransacaoUseCase
    {
        private readonly ITransacaoRepository _transacaoRepository;

        public CadastrarTransacaoUseCase(ITransacaoRepository transacaoRepository)
        {
            _transacaoRepository = transacaoRepository;
        }

        public void Execute(TransacaoDto transacaoDto)
        {
            Usuario usuario = new Usuario();
            Ativo ativo = new Ativo();
            Transacao transacao = new Transacao();

            transacao.Nome = transacaoDto.Nome;
            transacao.PortfolioId = transacaoDto.PortfolioId;
            transacao.Portfolio = new Portfolio(
                                        transacaoDto.Portfolio.Nome,
                                        transacaoDto.Portfolio.Descricao,
                                        usuario.Id,
                                        usuario);
            transacao.AtivoId = ativo.Id;
            transacao.Ativo = ativo;
            transacao.TipoTransacao = transacaoDto.TipoTransacao;
            transacao.Quantidade = transacaoDto.Quantidade;
            transacao.Preco = transacaoDto.Preco;

            _transacaoRepository.Adicionar(transacao);
        }
    }
}
