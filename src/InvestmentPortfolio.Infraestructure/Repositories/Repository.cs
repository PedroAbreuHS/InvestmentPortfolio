using InvestmentPortfolio.Domain.Entities;
using InvestmentPortfolio.Domain.Repositories;
using InvestmentPortfolio.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace InvestmentPortfolio.Infraestructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        protected AppDbContext _context;
        protected DbSet<T> _dbSet;

        #region Metodos CRUD
        public Repository(AppDbContext Context)
        {
            _context = Context;
            _dbSet = _context.Set<T>();
        }

        public async Task Adicionar(T entity)
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T?> ObterPorId(Guid id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<T>> ObterTodos()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task Remover(Guid id)
        {
            var entity = await ObterPorId(id);

            if (entity != null) _dbSet.Remove(entity);
            
            await _context.SaveChangesAsync();
        }
        #endregion

        #region 'Methods: Search'

        public T Find(params object[] Keys)
        {
            try
            {
                return _dbSet.Find(Keys);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            try
            {
                return _dbSet.AsNoTracking().FirstOrDefault(where);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public T Find(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, object> includes)
        {
            try
            {
                IQueryable<T> _query = _dbSet;

                if (includes != null)
                    _query = includes(_query) as IQueryable<T>;

                return _query.SingleOrDefault(predicate);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IQueryable<T> Query(Expression<Func<T, bool>> where)
        {
            try
            {
                return _dbSet.Where(where);
            }
            catch (Exception)
            {

                throw;
            }
        }
        //Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include
        public IQueryable<T> Query(Expression<Func< T, bool>> predicate, Func<IQueryable<T>, object> includes)
        {
            try
            {
                IQueryable<T> _query = _dbSet;

                if (includes != null)
                    _query = includes(_query) as IQueryable<T>;

                return _query.Where(predicate).AsQueryable();
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion
    }
}
