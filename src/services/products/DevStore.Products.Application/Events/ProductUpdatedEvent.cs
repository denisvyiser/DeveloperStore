using DevStore.Core.Mediatr.Events;
using DevStore.Products.Domain.Models.Entities;

namespace DevStore.Products.Application.Events
{
    public class ProductUpdatedEvent : Event<Product>
    {
        public ProductUpdatedEvent(Product _entity) : base(_entity)
        {
        }
    }
}
