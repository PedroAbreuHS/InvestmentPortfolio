
using InvestmentPortfolio.Application.DTOs;
using InvestmentPortfolio.Domain.Entities;
using InvestmentPortfolio.Domain.Repositories;
using System.ComponentModel.DataAnnotations;

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
            Validation(usuarioDto);

            Usuario? usuario = await _usuarioRepository.ObterPorId(id);

            if (usuario == null)
                throw new ArgumentException("Não há registro com o id informado.");

            if (!string.IsNullOrWhiteSpace(usuarioDto.Senha))
            {
                if (usuarioDto.Senha != usuarioDto.ConfirmarSenha)
                    throw new ArgumentException("Senha confirmação diferente da senha informada");

                usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuarioDto.Senha);
            }

            usuario.Nome = usuarioDto.Nome;
            usuario.Email = usuarioDto.Email;

            await _usuarioRepository.Atualizar(usuario);
        }

        private void Validation(UsuarioDto usuarioDto)
        {
            var validarEmail = new EmailAddressAttribute();

            if (!validarEmail.IsValid(usuarioDto.Email))
                throw new ArgumentException("Email inválido!");
        }
    }
}
