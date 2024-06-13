using InvestmentPortfolio.Domain.Entities;
using InvestmentPortfolio.Domain.Repositories;

namespace InvestmentPortfolio.Infraestructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        public Task<T> Adicionar(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> Atualizar(Guid id, T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<T> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public Task<T> Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
