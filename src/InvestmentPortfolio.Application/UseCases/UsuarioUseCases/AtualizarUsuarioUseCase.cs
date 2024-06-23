
using InvestmentPortfolio.Application.DTOs;
using InvestmentPortfolio.Domain.Entities;
using InvestmentPortfolio.Domain.Repositories;

namespace InvestmentPortfolio.Application.UseCases.UsuarioUseCases
{
    public class AtualizarUsuarioUseCase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public AtualizarUsuarioUseCase(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task Execute(Guid id, UsuarioDto usuarioDto)
        {
            Usuario? usuario = await _usuarioRepository.ObterPorId(id);

            if (usuario == null) throw new ArgumentException("Não há registro com o id informado.");

            usuario.Nome = usuarioDto.Nome;
            usuario.Email = usuarioDto.Email;
            usuario.Senha = usuarioDto.Senha;

            await _usuarioRepository.Atualizar(usuario);
        }
    }
}
