using Bogus;
using InvestmentPortfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentPortfolio.Tests.UsuarioTests
{
    [Collection("UsuarioTestsCollection")]
    public class UsuarioTestsBogus
    {
        public Usuario GerarUsuarioValido()
        {
            var usuario = new Faker<Usuario>("pt_BR")
                .CustomInstantiator(f => new Usuario(
                    f.Person.FullName,
                    f.Internet.Email(),
                    f.Internet.Password(8)));

            return usuario;
        }

        public Usuario GerarUsuarioInvalido()
        {
            var usuario = new Faker<Usuario>("pt_BR")
                .CustomInstantiator(f => new Usuario(
                    string.Empty, // Nome inválido
                    "email_invalido", // Email inválido
                    "123")); // Senha inválida

            return usuario;
        }
    }
}
