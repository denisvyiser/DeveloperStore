using DevStore.Core.Mediatr.Events;
using DevStore.Sales.Domain.Moldes.Entities;

namespace DevStore.Sales.Application.Events
{
    public class SaleUpdatedEvent : Event<Sale>
    {
        public SaleUpdatedEvent(Sale _entity) : base(_entity)
        {
        }
    }
}
