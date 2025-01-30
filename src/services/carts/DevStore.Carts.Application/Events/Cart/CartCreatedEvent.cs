using DevStore.Carts.Domain.Models.Entities;
using DevStore.Core.Mediatr.Events;

namespace DevStore.Carts.Application.Events
{
    public class CartCreatedEvent : Event<Cart>
    {
        public CartCreatedEvent(Cart _entity) : base(_entity)
        {
        }
    }
}
