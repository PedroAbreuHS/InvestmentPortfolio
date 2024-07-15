using Bogus;
using FluentAssertions;
using InvestmentPortfolio.Domain.Entities;
using InvestmentPortfolio.Domain.Enums;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentPortfolio.Tests.TransacaoTests
{
    [CollectionDefinition("TransacaoTestsCollection")]
    public class TransacaoTestsCollection : ICollectionFixture<TransacaoFixtureTests> { }

    public class TransacaoFixtureTests : IDisposable
    {
        private readonly TransacaoTestsBogus _transacaoTestsBogus;

        public AutoMocker Mocker;

        public TransacaoFixtureTests()
        {
            _transacaoTestsBogus = new TransacaoTestsBogus();
        }

        public Transacao GerarTransacaoValida()
        {
            return _transacaoTestsBogus.GerarTransacaoValida();
        }

        public Transacao GerarTransacaoInvalida()
        {
            return _transacaoTestsBogus.GerarTransacaoInvalida();
        }

        public void Dispose()
        {
        }
    }
}
    
