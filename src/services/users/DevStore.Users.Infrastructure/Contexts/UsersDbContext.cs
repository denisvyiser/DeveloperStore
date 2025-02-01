using DevStore.Db.Postgre.Contexts;
using DevStore.Infrastructure.Mappings;
using DevStore.Users.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevStore.Users.Infrastructure.Contexts
{
    public class UsersDbContext : BaseDbContext<UsersDbContext>
    {
        public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
