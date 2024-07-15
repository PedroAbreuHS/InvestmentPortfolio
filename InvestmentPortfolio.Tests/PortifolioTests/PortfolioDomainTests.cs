using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace InvestmentPortfolio.Tests.PortfolioTests
{
    [Collection("PortfolioTestsCollection")]
    public class PortfolioDomainTests
    {
        private readonly PortfolioFixtureTests _portfolioFixtureTests;

        public PortfolioDomainTests(PortfolioFixtureTests portfolioFixtureTests)
        {
            _portfolioFixtureTests = portfolioFixtureTests;
        }

        [Fact(DisplayName = "Portfolio Válido")]
        [Trait("Portfolio", "Unit")]
        public void AcertoConta_NovoAcertoConta_DeveEstarValido()
        {
            //Arrange
            var portfolio = _portfolioFixtureTests.GerarPortfolioValido();

            //Act
            var result = portfolio.IsValid();

            //Assert
            result.IsValid.Should().BeTrue();
            result.Errors.Should().BeEmpty();
        }

        [Fact(DisplayName = "Portfolio Inválido")]
        [Trait("Portfolio", "Unit")]
        public void AcertoConta_NovoAcertoConta_DeveEstarInvalido()
        {
            // Arrange
            var portfolio = _portfolioFixtureTests.GerarPortfolioInvalido();

            // Act
            var result = portfolio.IsValid();

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().NotBeEmpty();
        }
    }
}
