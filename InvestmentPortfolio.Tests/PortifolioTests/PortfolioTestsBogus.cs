using Bogus;
using InvestmentPortfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentPortfolio.Tests.PortfolioTests
{
    [Collection("PortfolioTestsCollection")]
    public class PortfolioTestsBogus
    {
        public Portfolio GerarPortfolioValido()
        {
            var portfolio = new Faker<Portfolio>("pt_BR")
                .CustomInstantiator(f => new Portfolio(
                    new Faker().Name.ToString(),
                    new Faker().Commerce.ToString(),
                    new Faker().Random.Guid(),
                    new Faker<Usuario>()));

            return portfolio;
        }

        public Portfolio GerarPortfolioInvalido()
        {
            var portfolio = new Faker<Portfolio>("pt_BR")
                .CustomInstantiator(f => new Portfolio(
                    string.Empty,  
                    string.Empty,  
                    Guid.Empty,    
                    null!));       

            return portfolio;
        }
    }
}
