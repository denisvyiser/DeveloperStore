using DevStore.Core.Mediatr.Events;
using DevStore.Users.Domain.Models.Entities;

namespace DevStore.Users.Application.Events
{
    public class UserRemovedEvent : Event<User>
    {
        public UserRemovedEvent(User _entity) : base(_entity)
        {
        }
    }
}
