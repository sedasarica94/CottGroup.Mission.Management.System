using CottGroup.Mission.Management.System.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CottGroup.Mission.Management.System.Infrastructure.Repositories.EntityFramework
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        IQueryable<TEntity> Query();
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> Query(Expression<Func<TEntity,bool>> predicate);
        Task<TEntity> GetAsync(int id);
        Task<TEntity> InsertAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task Delete(Expression<Func<TEntity, bool>> predicate); 
    }
}
