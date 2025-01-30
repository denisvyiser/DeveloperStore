using DevStore.Carts.Domain.Models.Entities;
using DevStore.Core.Mediatr.Events;

namespace DevStore.Carts.Application.Events
{
    public class CartRemovedEvent : Event<Cart>
    {
        public CartRemovedEvent(Cart _entity) : base(_entity)
        {
        }
    }
}
