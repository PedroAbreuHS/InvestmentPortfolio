using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace InvestmentPortfolio.Tests.AtivoTests
{
    [Collection("AtivoTestsCollection")]
    public class AtivoDomainTests
    {
        private readonly AtivoFixtureTests _ativoFixtureTests;

        public AtivoDomainTests(AtivoFixtureTests ativoFixtureTests)
        {
            _ativoFixtureTests = ativoFixtureTests;
        }

        [Fact(DisplayName = "Ativo Válido")]
        [Trait("Ativo", "Unit")]
        public void NovoAtivo_DeveEstarValido()
        {
            // Arrange
            var ativo = _ativoFixtureTests.GerarAtivoValido();

            // Act
            var result = ativo.IsValid();

            // Assert
            result.IsValid.Should().BeTrue();
            result.Errors.Should().BeEmpty();
        }

        [Fact(DisplayName = "Ativo Inválido")]
        [Trait("Ativo", "Unit")]
        public void NovoAtivo_DeveEstarInvalido()
        {
            // Arrange
            var ativo = _ativoFixtureTests.GerarAtivoInvalido();

            // Act
            var result = ativo.IsValid();

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().NotBeEmpty();
        }
    }
}
