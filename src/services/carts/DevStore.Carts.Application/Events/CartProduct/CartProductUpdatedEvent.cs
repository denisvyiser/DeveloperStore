using DevStore.Carts.Domain.Models.Entities;
using DevStore.Core.Mediatr.Events;

namespace DevStore.Carts.Application.Events
{
    public class CartProductUpdatedEvent : Event<CartProduct>
    {
        public CartProductUpdatedEvent(CartProduct _entity) : base(_entity)
        {
        }
    }
}
