using Bogus;
using InvestmentPortfolio.Domain.Entities;
using InvestmentPortfolio.Domain.Enums;
using InvestmentPortfolio.Tests.PortfolioTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentPortfolio.Tests.TransacaoTests
{
    [Collection("TransacaoTestsCollection")]
    public class TransacaoTestsBogus
    {
        public Transacao GerarTransacaoValida()
        {
            var transacao = new Faker<Transacao>("pt_BR")
                .CustomInstantiator(f => new Transacao(
                    f.Commerce.ProductName(),
                    f.Random.Guid(),
                    new PortfolioTestsBogus().GerarPortfolioValido(),
                    f.Random.Guid(),
                    new Faker<Ativo>().Generate(),
                    f.PickRandom<TipoTransacao>(),
                    f.Random.Int(1, 100),
                    f.Finance.Amount(1, 1000),
                    f.Date.Past()));

            return transacao;
        }

        public Transacao GerarTransacaoInvalida()
        {
            var transacao = new Faker<Transacao>("pt_BR")
                .CustomInstantiator(f => new Transacao(
                    string.Empty, // Nome inválido
                    Guid.Empty, // PortfolioId inválido
                    null!, // Portfolio inválido
                    Guid.Empty, // AtivoId inválido
                    null!, // Ativo inválido
                    TipoTransacao.Compra, // TipoTransacao
                    0, // Quantidade inválida
                    0m, // Preço inválido
                    DateTime.MinValue)); // DataTransacao inválida

            return transacao;
        }
    }
}
