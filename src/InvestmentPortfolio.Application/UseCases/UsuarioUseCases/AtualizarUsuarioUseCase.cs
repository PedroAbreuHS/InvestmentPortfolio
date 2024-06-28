
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
            // Obter o usuário pelo id
            Usuario? usuario = await _usuarioRepository.ObterPorId(id);

            if (usuario == null)
                throw new ArgumentException("Não há registro com o id informado.");

            // Validar confirmação de senha apenas se uma nova senha for fornecida
            if (!string.IsNullOrWhiteSpace(usuarioDto.Senha))
            {
                usuario.ValidarSenhaConfirmacao(usuarioDto.Senha, usuarioDto.ConfirmarSenha);
            }

            // Atualizar informações do usuário
            usuario.AtualizarInformacoes(usuarioDto.Nome, usuarioDto.Email, usuarioDto.Senha);

            // Chamar o repositório para atualizar o usuário
            await _usuarioRepository.Atualizar(usuario);
        }
    }

}
