using DevStore.Core.Helpers.Repository;
using DevStore.Core.Models.Entities;
using DevStore.Core.Models.ValueObjects;
using DevStore.Users.Domain.Models.Enums;

namespace DevStore.Users.Domain.Models.Entities
{
    public class User : Entity
    {
        public User(Guid id,string email, string userName, string password, string phone, Status status, Role role)
        {
            Id = id;
            Email = email;
            UserName = userName;
            Password = password;
            Phone = phone;
            Status = status;
            Role = role;
        }

        public string Email { get; set; }

        [PropertyValidation]
        public string UserName { get; set; }
        public string Password { get; set; }
        public Name Name { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
        public Status Status { get; set; }
        public Role Role { get; set; }
    }
}
