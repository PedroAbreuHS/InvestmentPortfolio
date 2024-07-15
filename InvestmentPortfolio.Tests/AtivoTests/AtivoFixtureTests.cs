using InvestmentPortfolio.Domain.Entities;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentPortfolio.Tests.AtivoTests
{
    [CollectionDefinition("AtivoTestsCollection")]
    public class AtivoTestsCollection : ICollectionFixture<AtivoFixtureTests> { }

    public class AtivoFixtureTests : IDisposable
    {
        private readonly AtivoTestsBogus _ativoTestsBogus;

        public AutoMocker Mocker;

        public AtivoFixtureTests()
        {
            _ativoTestsBogus = new AtivoTestsBogus();
        }

        public Ativo GerarAtivoValido()
        {
            return _ativoTestsBogus.GerarAtivoValido();
        }

        public Ativo GerarAtivoInvalido()
        {
            return _ativoTestsBogus.GerarAtivoInvalido();
        }

        public void Dispose()
        {
        }
    }
}
