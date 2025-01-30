using DevStore.Core.Interfaces;
using DevStore.Core.Models.Entities;
using DevStore.Core.Models.Pagination;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DevStore.Infrastructure.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Entity
    {
        public DbContext context;

        protected BaseRepository(DbContext context)
        {
            this.context = context;
        }

        public DbSet<TEntity> DbSet()
        {
            return context.Set<TEntity>();
        }

        public async Task<PaginatedList<TEntity>> ListPagedAsync(List<Order> order, Page page, List<Filter> filter, params Expression<Func<TEntity, object>>[] properties)
        {
            var result = await DbSet()
                .IncludeProperties(properties)
                .Where(filter)
                .OrderMultiple(order)
                .Skip((page.Index - 1) * page.Quantity)
                .Take(page.Quantity)
                .AsQueryable().AsNoTracking().ToListAsync();

            var totalRecords = await DbSet().Where(filter).CountAsync();


            var pagination = new PaginationObject
            {
                Order = order,
                Page = page,
                TotalItem = totalRecords
            };

            return new PaginatedList<TEntity>(result.AsQueryable(), pagination);

        }

        public async Task InsertAsync(TEntity entity)
        {
            context.Add(entity);
            await SaveChangesAsync();


        }
        public async Task UpdateAsync(TEntity entity)
        {
            // var context = await GetFirstByExpressionAsync(c=> c.id == entity.id && c.version == version);

            //Context.Entry(context).CurrentValues.SetValues(entity);



            //Context.Entry(entity).State = EntityState.Modified;
            DbSet().Update(entity);

            await SaveChangesAsync();

            //Context.Entry(entity).State = EntityState.Detached;

            //     DbSet().Update(entity);
        }

        public async Task InsertRangeAsync(IList<TEntity> entities)
        {
            await DbSet().AddRangeAsync(entities);
        }

        public async Task DeleteAsync(TEntity entity)
        {

            //context.Entry(entity).State = EntityState.Deleted;

            DbSet().Remove(entity);

            await SaveChangesAsync();
        }

        public async Task<TEntity> GetFirstByExpressionAsync(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] properties)
        {
            return await DbSet().IncludeProperties(properties).AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
