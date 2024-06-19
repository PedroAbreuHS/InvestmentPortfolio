
using InvestmentPortfolio.Application.DTOs;
using InvestmentPortfolio.Domain.Entities;
using InvestmentPortfolio.Domain.Repositories;

namespace InvestmentPortfolio.Application.UseCases.AtivoUseCases
{
    public class AtualizarAtivoUseCase
    {
        private readonly IAtivoRepository _ativoRepository;

        public AtualizarAtivoUseCase(IAtivoRepository ativoRepository)
        {
            _ativoRepository = ativoRepository;
        }

        public async Task Execute(Guid id, AtivoDto ativoDto)
        {
            Ativo? ativo = await _ativoRepository.ObterPorId(id);

            if (ativo == null) throw new ArgumentException("Não há registro com o id informado.");

            ativo.Id = id;
            ativo.TipoAtivo = ativoDto.TipoAtivo;
            ativo.Codigo = ativoDto.Codigo;
            ativo.Nome = ativoDto.Nome;
           

            await _ativoRepository.Atualizar(ativo);
        }
    }
}
