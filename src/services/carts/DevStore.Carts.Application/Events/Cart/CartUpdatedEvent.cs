using DevStore.Carts.Domain.Models.Entities;
using DevStore.Core.Mediatr.Events;

namespace DevStore.Carts.Application.Events
{
    public class CartUpdatedEvent : Event<Cart>
    {
        public CartUpdatedEvent(Cart _entity) : base(_entity)
        {
        }
    }
}
