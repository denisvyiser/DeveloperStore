using DevStore.Users.Domain.Interfaces.Repositories;
using DevStore.Users.Domain.Models.Entities;
using DevStore.Users.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DevStore.Infrastructure.Repositories
{
    public class UsersRepository : BaseRepository<User>, IUsersRepository
    {
        public UsersRepository(UsersDbContext context) : base(context)
        {
        }

        public async Task<User> GetUserByCredentials(string userName, string password)
        {
            return await DbSet().Where(c => c.UserName == userName && c.Password == password).FirstOrDefaultAsync();
        }
    }
}
