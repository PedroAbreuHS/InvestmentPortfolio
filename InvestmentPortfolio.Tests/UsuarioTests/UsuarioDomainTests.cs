using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentPortfolio.Tests.UsuarioTests
{
    [Collection("UsuarioTestsCollection")]
    public class UsuarioDomainTests
    {
        private readonly UsuarioFixtureTests _usuarioFixtureTests;

        public UsuarioDomainTests(UsuarioFixtureTests usuarioFixtureTests)
        {
            _usuarioFixtureTests = usuarioFixtureTests;
        }

        [Fact(DisplayName = "Usuário Válido")]
        [Trait("Usuário", "Unit")]
        public void NovoUsuario_DeveEstarValido()
        {
            // Arrange
            var usuario = _usuarioFixtureTests.GerarUsuarioValido();

            // Act
            var result = usuario.IsValid();

            // Assert
            result.IsValid.Should().BeTrue();
            result.Errors.Should().BeEmpty();
        }

        [Fact(DisplayName = "Usuário Inválido")]
        [Trait("Usuário", "Unit")]
        public void NovoUsuario_DeveEstarInvalido()
        {
            // Arrange
            var usuario = _usuarioFixtureTests.GerarUsuarioInvalido();

            // Act
            var result = usuario.IsValid();

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().NotBeEmpty();
        }
    }

}
