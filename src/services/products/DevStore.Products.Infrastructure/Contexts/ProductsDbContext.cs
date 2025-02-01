using DevStore.Db.Postgre.Contexts;
using DevStore.Infrastructure.Mappings;
using DevStore.Products.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevStore.Products.Infrastructure.Contexts
{
    public class ProductsDbContext : BaseDbContext<ProductsDbContext>
    {
        public ProductsDbContext(DbContextOptions<ProductsDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}

//Add-Migration newinicial -Project DevStore.Products.Infrastructure -Context ProductsDbContext -verbose