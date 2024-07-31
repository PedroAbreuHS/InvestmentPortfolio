using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentPortfolio.Application.DTOs
{
    public class UsuarioResponseAutenticaoDto
    {
        public UsuarioResponseAutenticaoDto(UsuarioDto user)
        {
            this.User = user;
        }

        public UsuarioDto User { get; set; }
    }
}
