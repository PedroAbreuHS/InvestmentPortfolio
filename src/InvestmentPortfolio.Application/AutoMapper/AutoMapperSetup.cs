using AutoMapper;
using InvestmentPortfolio.Application.DTOs;
using InvestmentPortfolio.Domain.Entities;

namespace InvestmentPortfolio.Application.AutoMapper
{
    public class AutoMapperSetup: Profile
    {
        public AutoMapperSetup() 
        { 
            #region ViewModelToDomain

            CreateMap<UsuarioDto, Usuario>();
            CreateMap<PortfolioDto, Portfolio>();

            #endregion

            #region DomainToViewModel

            CreateMap<Usuario, UsuarioDto>();
            CreateMap<Portfolio, PortfolioDto>();

            #endregion
        } 
    }
}
