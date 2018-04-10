using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.MySqlRepositories
{
    public class BaseRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : class
    {
        private readonly ApplicationDbContext _dbContext;
        private DbSet<TEntity> entities;
        public BaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            entities = _dbContext.Set<TEntity>();

        }
        public Task<TEntity> AddAsync(TEntity entity)
        {
            var result = entities.Add(entity);
            _dbContext.SaveChanges();
            return Task.FromResult(entity);
        }

        public Task AddAsync(List<TEntity> entities)
        {
            //foreach (var entity in entities.AsEnumerable())
            //{
            //    entity.ad

            //} ;
            return Task.FromResult(entities);
        }

        public Task DeleteAsync(TKey id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            _dbContext.SaveChanges();
            return Task.FromResult(entity);
        }

        public Task DeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> Get()
        {
            return entities.AsQueryable();
            //throw new NotImplementedException();
        }

        public Task<TEntity> GetAsync(TKey id)
        {
            TEntity result = entities.Find(id);
            return Task.FromResult(result);
        }

        public Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> where)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _dbContext.SaveChanges();
            return Task.FromResult(entity);
        }

        public Task UpdateAsync(List<TEntity> entities)
        {
            throw new NotImplementedException();
        }
    }

    public interface IGenericRepository<TEntity, TKey>
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task AddAsync(List<TEntity> entities);
        Task DeleteAsync(TKey id);
        Task DeleteAsync(TEntity entity);
        Task DeleteAsync(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> Get();
        Task<TEntity> GetAsync(TKey id);
        Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> where);
        Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
        Task UpdateAsync(TEntity entity);
        Task UpdateAsync(List<TEntity> entities);
    }
}
