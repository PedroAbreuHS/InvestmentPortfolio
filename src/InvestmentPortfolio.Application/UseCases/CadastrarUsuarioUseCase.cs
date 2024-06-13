
using InvestmentPortfolio.Application.DTOs;
using InvestmentPortfolio.Domain.Entities;
using InvestmentPortfolio.Domain.Repositories;
using System.ComponentModel.DataAnnotations;

namespace InvestmentPortfolio.Application.UseCases
{
    public class CadastrarUsuarioUseCase 
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public CadastrarUsuarioUseCase(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public void Execute(UsuarioDto usuarioDto) 
        {
            Validation(usuarioDto);

            var usuario = new Usuario(usuarioDto.Nome, usuarioDto.Email, usuarioDto.Senha);

            _usuarioRepository.Adicionar(usuario);
        }

        private void Validation(UsuarioDto usuarioDto)
        {
            if (usuarioDto.Senha != usuarioDto.ConfirmarSenha) throw new ArgumentException("Senha confirmação diferente da senha informada");

            var validarEmail = new EmailAddressAttribute();

            if (!validarEmail.IsValid(usuarioDto.Email)) throw new ArgumentException("Email inválido!");
        }
    }
}
