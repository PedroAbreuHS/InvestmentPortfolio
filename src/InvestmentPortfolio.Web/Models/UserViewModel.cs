﻿using Microsoft.CodeAnalysis.Options;

namespace InvestmentPortfolio.Web.Models
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
    }
}
