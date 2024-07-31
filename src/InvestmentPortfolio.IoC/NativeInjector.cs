using InvestmentPortfolio.Application.UseCases;
using InvestmentPortfolio.Application.UseCases.AtivoUseCases;
using InvestmentPortfolio.Application.UseCases.PortfolioUseCases;
using InvestmentPortfolio.Application.UseCases.TransacaoUseCase;
using InvestmentPortfolio.Application.UseCases.UsuarioUseCases;
using InvestmentPortfolio.Domain.Repositories;
using InvestmentPortfolio.Infraestructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace InvestmentPortfolio.IoC
{
    public static class NativeInjector
    {
        public static void RegisterServices(IServiceCollection service)
        {
            #region Services
            service.AddScoped<AutenticarUsuarioUseCase>();
            service.AddScoped<CadastrarUsuarioUseCase>();
            service.AddScoped<ObterTodosAtivosUseCase>();
            service.AddScoped<ObterAtivoPorIdUseCase>();
            service.AddScoped<AtualizarAtivoUseCase>();
            service.AddScoped<RemoverAtivoUseCase>();
            service.AddScoped<CadastrarPortfolioUseCase>();
            service.AddScoped<CadastrarTransacaoUseCase>();
            service.AddScoped<CadastrarAtivoUseCase>();
            service.AddScoped<ObterTodosUsuariosUseCase>();
            service.AddScoped<ObterUsuarioPorIdUseCase>();
            service.AddScoped<ObterPortfolioPorIdUseCase>();
            service.AddScoped<ObterTodosPortfoliosUseCase>();
            #endregion

            #region Repositories
            service.AddScoped<IUsuarioRepository, UsuarioRepository>();
            service.AddScoped<IAtivoRepository, AtivoRepository>();
            service.AddScoped<IPortfolioRepository, PortfolioRepository>();
            service.AddScoped<ITransacaoRepository, TransacaoRepository>();
            #endregion
        }
    }
}
