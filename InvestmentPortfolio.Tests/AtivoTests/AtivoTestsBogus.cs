using Bogus;
using InvestmentPortfolio.Domain.Entities;
using InvestmentPortfolio.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentPortfolio.Tests.AtivoTests
{
    [Collection("AtivoTestsCollection")]
    public class AtivoTestsBogus
    {
        public Ativo GerarAtivoValido()
        {
            var ativo = new Faker<Ativo>("pt_BR")
                .CustomInstantiator(f => new Ativo(
                    f.Commerce.ProductName(),
                    f.PickRandom<TipoAtivo>(),
                    f.PickRandom<Codigo>()
                ));

            return ativo;
        }

        public Ativo GerarAtivoInvalido()
        {
            var ativo = new Faker<Ativo>("pt_BR")
                .CustomInstantiator(f => new Ativo(
                    string.Empty,  // Nome inválido
                    default,       // TipoAtivo inválido
                    default));       // Codigo inválido

            return ativo;
        }
    }
}
