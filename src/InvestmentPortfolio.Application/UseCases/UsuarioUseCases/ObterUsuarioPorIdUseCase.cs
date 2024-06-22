
using InvestmentPortfolio.Domain.Entities;
using InvestmentPortfolio.Domain.Repositories;

namespace InvestmentPortfolio.Application.UseCases.UsuarioUseCases
{
    public class ObterUsuarioPorIdUseCase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public ObterUsuarioPorIdUseCase(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Usuario?> Execute(Guid id)
        {
            Usuario? usuario = await _usuarioRepository.ObterPorId(id);
            if (usuario is not null)
            {
                usuario.Senha = "";
            }

            return usuario;
        }
    }
}
