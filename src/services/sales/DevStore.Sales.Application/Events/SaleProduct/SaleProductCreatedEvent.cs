using DevStore.Core.Mediatr.Events;
using DevStore.Sales.Domain.Moldes.Entities;

namespace DevStore.Sales.Application.Events
{
    public class SaleProductCreatedEvent : Event<SaleProduct>
    {
        public SaleProductCreatedEvent(SaleProduct _entity) : base(_entity)
        {
        }
    }
}
