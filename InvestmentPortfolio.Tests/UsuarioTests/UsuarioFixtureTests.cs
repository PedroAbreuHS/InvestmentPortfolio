using Bogus;
using InvestmentPortfolio.Domain.Entities;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentPortfolio.Tests.UsuarioTests
{
    [CollectionDefinition("UsuarioTestsCollection")]
    public class UsuarioTestsCollection : ICollectionFixture<UsuarioFixtureTests> { }

    public class UsuarioFixtureTests : IDisposable
    {
        private readonly UsuarioTestsBogus _usuarioTestsBogus;

        public AutoMocker Mocker;

        public UsuarioFixtureTests()
        {
            _usuarioTestsBogus = new UsuarioTestsBogus();
        }

        public Usuario GerarUsuarioValido()
        {
            return _usuarioTestsBogus.GerarUsuarioValido();
        }

        public Usuario GerarUsuarioInvalido()
        {
            return _usuarioTestsBogus.GerarUsuarioInvalido();
        }

        public void Dispose()
        {
        }
    }

    

}
