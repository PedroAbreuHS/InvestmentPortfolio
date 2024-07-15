using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentPortfolio.Tests.TransacaoTests
{
    [Collection("TransacaoTestsCollection")]
    public class TransacaoDomainTests
    {
        private readonly TransacaoFixtureTests _transacaoFixtureTests;

        public TransacaoDomainTests(TransacaoFixtureTests transacaoFixtureTests)
        {
            _transacaoFixtureTests = transacaoFixtureTests;
        }

        [Fact(DisplayName = "Transação Válida")]
        [Trait("Transação", "Unit")]
        public void NovaTransacao_DeveEstarValida()
        {
            // Arrange
            var transacao = _transacaoFixtureTests.GerarTransacaoValida();

            // Act
            var result = transacao.IsValid();

            // Assert
            result.IsValid.Should().BeTrue();
            result.Errors.Should().BeEmpty();
        }

        [Fact(DisplayName = "Transação Inválida")]
        [Trait("Transação", "Unit")]
        public void NovaTransacao_DeveEstarInvalida()
        {
            // Arrange
            var transacao = _transacaoFixtureTests.GerarTransacaoInvalida();

            // Act
            var result = transacao.IsValid();

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().NotBeEmpty();
        }
    }
}
