using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentPortfolio.Application.DTOs
{
    public class UsuarioRequestAutenticaoDto
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
