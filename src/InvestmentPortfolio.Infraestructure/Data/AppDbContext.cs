
using InvestmentPortfolio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace InvestmentPortfolio.Infraestructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Ativo> Ativos { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        private readonly IConfiguration _config;

        public AppDbContext(IConfiguration config, DbContextOptions options) : base(options)
        {
            _config = config;
        }

        public AppDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = _config.GetConnectionString("");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }


    }
}
