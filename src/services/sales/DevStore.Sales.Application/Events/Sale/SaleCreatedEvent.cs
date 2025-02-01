using DevStore.Core.Mediatr.Events;
using DevStore.Sales.Domain.Moldes.Entities;

namespace DevStore.Sales.Application.Events
{
    public class SaleCreatedEvent : Event<Sale>
    {
        public SaleCreatedEvent(Sale _entity) : base(_entity)
        {
        }
    }
}
