using DevStore.Core.Mediatr.Events;
using DevStore.Products.Domain.Models.Entities;

namespace DevStore.Products.Application.Events
{
    public class ProductCreatedEvent : Event<Product>
    {
        public ProductCreatedEvent(Product _entity) : base(_entity)
        {
        }
    }
}
