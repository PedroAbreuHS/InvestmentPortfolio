
using InvestmentPortfolio.Domain.Entities;
using InvestmentPortfolio.Domain.Repositories;

namespace InvestmentPortfolio.Application.UseCases.UsuarioUseCases
{
    public class ObterTodosUsuariosUseCase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public ObterTodosUsuariosUseCase(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<List<Usuario>> Execute()
        {
            List<Usuario> usuarios = await _usuarioRepository.ObterTodos();
            usuarios.ForEach(usuario => { usuario.Senha = ""; });
            return usuarios;
        }
    }
}
