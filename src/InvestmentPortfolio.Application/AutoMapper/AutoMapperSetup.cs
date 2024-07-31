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

            #endregion

            #region DomainToViewModel

            CreateMap<Usuario, UsuarioDto>();

            #endregion
        } 
    }
}
