using DevStore.Db.Postgre.Contexts;
using DevStore.Infrastructure.Mappings;
using DevStore.Sales.Domain.Moldes.Entities;
using DevStore.Sales.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace DevStore.Sales.Infrastructure.Contexts
{
    public class SalesDbContext : BaseDbContext<SalesDbContext>
    {
        public SalesDbContext(DbContextOptions<SalesDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Sale> Sales { get; set; }

        public virtual DbSet<SaleProduct> SaleProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SaleMap());
            modelBuilder.ApplyConfiguration(new SaleProductMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
