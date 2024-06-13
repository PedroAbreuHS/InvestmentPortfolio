using InvestmentPortfolio.Domain.Entities;

namespace InvestmentPortfolio.Domain.Repositories
{
    public interface IRepository<T> where T : EntityBase
    {
        Task<T> Adicionar(T entity);

        Task<T> ObterTodos();

        Task<T> ObterPorId(Guid id);

        Task<T> Atualizar(Guid id, T entity);

        Task<T> Remover(Guid id);
    }
}
