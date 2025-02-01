using Microsoft.EntityFrameworkCore;

namespace DevStore.Db.Postgre.Contexts
{
    public class BaseDbContext<TContext> : DbContext where TContext : DbContext
    {
        public BaseDbContext(DbContextOptions<TContext> options) : base(options)
        {
        }

        /// <summary>
        /// Save Changes method overrride
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>Integer value to confirme data quantity updated</returns>
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            foreach (var entry in ChangeTracker.Entries().Where(entity => entity.Entity.GetType().GetProperty("CreatedAt") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreatedAt").CurrentValue = DateTime.Now.ToUniversalTime();
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("UpdatedAt").CurrentValue = DateTime.Now.ToUniversalTime();
                    entry.Property("CreatedAt").IsModified = false;
                    entry.Property("Version").CurrentValue = entry.OriginalValues.GetValue<int>("Version") + 1;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
