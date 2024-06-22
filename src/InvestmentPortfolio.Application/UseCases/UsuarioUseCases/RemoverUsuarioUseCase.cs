
using InvestmentPortfolio.Domain.Entities;
using InvestmentPortfolio.Domain.Repositories;

namespace InvestmentPortfolio.Application.UseCases.UsuarioUseCases
{
    public class RemoverUsuarioUseCase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public RemoverUsuarioUseCase(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task Execute(Guid id)
        {
            Usuario? usuario = await _usuarioRepository.ObterPorId(id);

            if (usuario == null) throw new ArgumentException("Não há registro com o id informado.");

            await _usuarioRepository.Remover(id);
        }
    }
}
