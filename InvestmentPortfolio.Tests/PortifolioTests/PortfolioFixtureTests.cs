using InvestmentPortfolio.Domain.Entities;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentPortfolio.Tests.PortfolioTests
{
    [CollectionDefinition("PortfolioTestsCollection")]
    public class PortfolioTestsCollection : ICollectionFixture<PortfolioFixtureTests> { }
    public class PortfolioFixtureTests : IDisposable
    {
        private readonly PortfolioTestsBogus _portfolioTestsBogus;

        public AutoMocker Mocker;

        public PortfolioFixtureTests()
        {
            _portfolioTestsBogus = new PortfolioTestsBogus();
        }

        public Portfolio GerarPortfolioValido()
        {
            return _portfolioTestsBogus.GerarPortfolioValido();
        }

        public void Dispose()
        {
        }

        public Portfolio GerarPortfolioInvalido()
        {
            return _portfolioTestsBogus.GerarPortfolioInvalido();
        }
    }
}
