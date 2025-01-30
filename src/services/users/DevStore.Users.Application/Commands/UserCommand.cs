using DevStore.Core.Mediatr.Commands;
using DevStore.Core.Models.ValueObjects;
using DevStore.Users.Domain.Models.Enums;

namespace DevStore.Users.Application.Commands
{
    public abstract class UserCommand : Command
    {
        public string Email { get; protected set; }
        public string UserName { get; protected set; }
        public string Password { get; protected set; }
        public Name Name { get; protected set; }
        public Address Address { get; protected set; }
        public string Phone { get; protected set; }
        public Status Status { get; protected set; }
        public Role Role { get; protected set; }
    }
}
