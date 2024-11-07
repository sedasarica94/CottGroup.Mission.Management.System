using CottGroup.Mission.Management.System.Infrastructure.Data;
using CottGroup.Mission.Management.System.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CottGroup.Mission.Management.System.Infrastructure.Repositories.EntityFramework.Impl
{
    public class EntityFrameworkRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly DataContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public EntityFrameworkRepository(DataContext _dataContext)
        {
            _dbContext = _dataContext;
            _dbSet = _dbContext.Set<TEntity>();
        }


        public async Task Delete(Expression<Func<TEntity, bool>> predicate)
        {
            var entities = _dbSet.Where(predicate);
            _dbSet.RemoveRange(entities);
            await _dbContext.SaveChangesAsync();
        } 

        public async Task<TEntity> GetAsync(int id) => await _dbSet.FindAsync(id);

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public IQueryable<TEntity> Query() => _dbSet;
        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate) =>await _dbSet.Where(predicate).ToListAsync();

        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate) => _dbSet.Where(predicate);

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
