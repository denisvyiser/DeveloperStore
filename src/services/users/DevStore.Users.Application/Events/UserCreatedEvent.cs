using DevStore.Core.Mediatr.Events;
using DevStore.Users.Domain.Models.Entities;

namespace DevStore.Users.Application.Events
{
    public class UserCreatedEvent : Event<User>
    {
        public UserCreatedEvent(User _entity) : base(_entity)
        {
        }
    }
}
