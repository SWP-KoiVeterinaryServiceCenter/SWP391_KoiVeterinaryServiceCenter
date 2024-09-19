using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface IGenericRepository<TEntity> where TEntity:BaseEntity,ICreatedBy,IModificationBy,IDeletedBy 
    {
        Task<List<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity?> GetByIdAsync(Guid id);
        Task<TEntity?> GetByIdAsync(Guid id, params Expression<Func<TEntity, object>>[] includes);
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void UpdateRange(List<TEntity> entities);
        void SoftRemove(TEntity entity);
        Task AddRangeAsync(List<TEntity> entities);
        void SoftRemoveRange(List<TEntity> entities);
        Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] includes);
    }
}
