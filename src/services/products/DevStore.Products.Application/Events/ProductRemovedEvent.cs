using DevStore.Core.Mediatr.Events;
using DevStore.Products.Domain.Models.Entities;

namespace DevStore.Products.Application.Events
{
    public class ProductRemovedEvent : Event<Product>
    {
        public ProductRemovedEvent(Product _entity) : base(_entity)
        {
        }
    }
}
