using DevStore.Core.Mediatr.Events;
using DevStore.Sales.Domain.Moldes.Entities;

namespace DevStore.Sales.Application.Events
{
    public class SaleProductUpdatedEvent : Event<SaleProduct>
    {
        public SaleProductUpdatedEvent(SaleProduct _entity) : base(_entity)
        {
        }
    }
}
