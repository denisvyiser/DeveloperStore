using DevStore.Carts.Domain.Models.Entities;
using DevStore.Core.Mediatr.Events;

namespace DevStore.Carts.Application.Events
{
    public class CartProductRemovedEvent : Event<CartProduct>
    {
        public CartProductRemovedEvent(CartProduct _entity) : base(_entity)
        {
        }
    }
}
