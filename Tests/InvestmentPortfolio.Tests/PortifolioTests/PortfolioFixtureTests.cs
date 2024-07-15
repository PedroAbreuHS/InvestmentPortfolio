using InvestmentPortfolio.Domain.Entities;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentPortfolio.Tests.PortfolioTests
{
    public class PortfolioFixtureTests : IDisposable
    {
        private readonly PortfolioTestsBogus _portfolioTestsBogus;

        public AutoMocker Mocker;

        public PortfolioFixtureTests(PortfolioTestsBogus portfolioTestsBogus)
        {
            _portfolioTestsBogus = portfolioTestsBogus;
        }

        public Portfolio GerarPortfolioValido()
        {
            return _portfolioTestsBogus.GerarPortfolioValido();
        }

        public void Dispose()
        {
        }
    }
}
