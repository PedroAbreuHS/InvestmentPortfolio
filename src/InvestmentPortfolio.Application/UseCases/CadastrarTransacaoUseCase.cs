
using InvestmentPortfolio.Application.DTOs;
using InvestmentPortfolio.Domain.Entities;
using InvestmentPortfolio.Domain.Repositories;

namespace InvestmentPortfolio.Application.UseCases
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
            Transacao transacao = new(transacaoDto.Nome, 
                                      transacaoDto.PortfolioId, 
                                      transacaoDto.Portfolio,
                                      transacaoDto.AtivoId,
                                      transacaoDto.Ativo, 
                                      transacaoDto.TipoTransacao, 
                                      transacaoDto.Quantidade, 
                                      transacaoDto.Preco, 
                                      transacaoDto.DataTransacao);

            _transacaoRepository.Adicionar(transacao);
        }
    }
}
