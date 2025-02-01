using DevStore.Carts.Domain.Models.Entities;
using DevStore.Carts.Infrastructure.Mappings;
using DevStore.Db.Postgre.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DevStore.Carts.Infrastructure.Contexts
{
    public class CartsDbContext : BaseDbContext<CartsDbContext>
    {
        public CartsDbContext(DbContextOptions<CartsDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Cart> Carts { get; set; }

        public virtual DbSet<CartProduct> CartProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CartMap());
            modelBuilder.ApplyConfiguration(new CartProductMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
