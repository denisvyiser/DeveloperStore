using DevStore.Core.Models.Entities;
using DevStore.Core.Models.Pagination;
using System.Linq.Expressions;

namespace DevStore.Core.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : Entity
    {
        Task<PaginatedList<TEntity>> ListPagedAsync(List<Order> order, Page page, List<Filter> filter, params Expression<Func<TEntity, object>>[] properties);
        Task DeleteAsync(TEntity entity);
        Task InsertAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task InsertRangeAsync(IList<TEntity> entities);
        Task<int> SaveChangesAsync();
        Task<TEntity> GetFirstByExpressionAsync(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] properties);
    }
}
