using AutoMapper;
using InvestmentPortfolio.Application.DTOs;
using InvestmentPortfolio.Domain.Entities;
using InvestmentPortfolio.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentPortfolio.Application.UseCases.UsuarioUseCases
{
    public class AutenticarUsuarioUseCase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public AutenticarUsuarioUseCase(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<Usuario> Execute(UsuarioRequestAutenticaoDto usuarioAutenticacaoDTO)
        {
            Validation(usuarioAutenticacaoDTO);

            Usuario usuario = new Usuario(
                string.Empty,
                usuarioAutenticacaoDTO.Email,
                usuarioAutenticacaoDTO.Senha);

            Usuario _user = this._usuarioRepository.Find(x => x.Email.ToLower() == usuario.Email.ToLower()
                                                    && x.Senha.ToLower() == usuario.Senha.ToLower());
            if (_user == null)
                throw new Exception("User not found");

            return _user;
        }

        private void Validation(UsuarioRequestAutenticaoDto usuarioDto)
        {
            if (string.IsNullOrEmpty(usuarioDto.Email) || string.IsNullOrEmpty(usuarioDto.Senha))
                throw new Exception("Email/Password are required.");
        }
    }
}
