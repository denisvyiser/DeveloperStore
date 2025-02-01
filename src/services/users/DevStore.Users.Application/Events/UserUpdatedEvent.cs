using DevStore.Core.Mediatr.Events;
using DevStore.Users.Domain.Models.Entities;

namespace DevStore.Users.Application.Events
{
    public class UserUpdatedEvent : Event<User>
    {
        public UserUpdatedEvent(User _entity) : base(_entity)
        {
        }
    }
}
