
using InvestmentPortfolio.Application.DTOs;
using InvestmentPortfolio.Domain.Entities;
using InvestmentPortfolio.Domain.Repositories;

namespace InvestmentPortfolio.Application.UseCases
{
    public class CadastrarAtivoUseCase
    {
        private readonly IAtivoRepository _ativoRepository;

        public CadastrarAtivoUseCase(IAtivoRepository ativoRepository)
        {
            _ativoRepository = ativoRepository;
        }

        public void Execute(AtivoDto ativoDto)
        {
            Ativo ativoNovo = new(ativoDto.Nome, ativoDto.TipoAtivo, ativoDto.Codigo);

            _ativoRepository.Adicionar(ativoNovo);
        }

    }
}
