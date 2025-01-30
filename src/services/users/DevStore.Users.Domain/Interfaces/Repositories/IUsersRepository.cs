using DevStore.Core.Interfaces;
using DevStore.Users.Domain.Models.Entities;

namespace DevStore.Users.Domain.Interfaces.Repositories
{
    public interface IUsersRepository : IBaseRepository<User>
    {
        Task<User> GetUserByCredentials(string userName, string password);
    }
}
