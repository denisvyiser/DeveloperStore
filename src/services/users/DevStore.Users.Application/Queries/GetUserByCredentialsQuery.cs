using DevStore.Core.Mediatr.Queries;
using DevStore.Users.Domain.Models.Entities;

namespace DevStore.Users.Application.Queries
{
    public class GetUserByCredentialsQuery : Query<User>
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public override bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(UserName) && !string.IsNullOrWhiteSpace(Password);
        }
    }
}