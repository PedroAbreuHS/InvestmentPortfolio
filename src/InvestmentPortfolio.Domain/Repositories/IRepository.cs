using InvestmentPortfolio.Domain.Entities;

namespace InvestmentPortfolio.Domain.Repositories
{
    public interface IRepository<T> where T : EntityBase
    {
        Task Adicionar(T entity);

        Task<List<T>> ObterTodos();

        Task<T?> ObterPorId(Guid id);

        Task Atualizar(T entity);

        Task Remover(Guid id);
    }
}
