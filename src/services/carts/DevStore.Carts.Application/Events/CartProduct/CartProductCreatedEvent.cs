using DevStore.Carts.Domain.Models.Entities;
using DevStore.Core.Mediatr.Events;

namespace DevStore.Carts.Application.Events
{
    public class CartProductCreatedEvent : Event<CartProduct>
    {
        public CartProductCreatedEvent(CartProduct _entity) : base(_entity)
        {
        }
    }
}
