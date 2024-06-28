using InvestmentPortfolio.Application.DTOs;
using InvestmentPortfolio.Domain.Entities;
using InvestmentPortfolio.Domain.Repositories;
using System.ComponentModel.DataAnnotations;

namespace InvestmentPortfolio.Application.UseCases.UsuarioUseCases
{
    public class CadastrarUsuarioUseCase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public CadastrarUsuarioUseCase(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task Execute(UsuarioDto usuarioDto)
        {
            Validar(usuarioDto);

            var usuario = new Usuario(usuarioDto.Nome, usuarioDto.Email, usuarioDto.Senha);

            await _usuarioRepository.Adicionar(usuario);
        }

        private void Validar(UsuarioDto usuarioDto)
        {
            var usuario = new Usuario(usuarioDto.Nome, usuarioDto.Email, usuarioDto.Senha);
            usuario.ValidarSenhaConfirmacao(usuarioDto.Senha, usuarioDto.ConfirmarSenha);
        }
    }

}
