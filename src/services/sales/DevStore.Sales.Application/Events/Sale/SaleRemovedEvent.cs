using DevStore.Core.Mediatr.Events;
using DevStore.Sales.Domain.Moldes.Entities;

namespace DevStore.Sales.Application.Events
{
    public class SaleRemovedEvent : Event<Sale>
    {
        public SaleRemovedEvent(Sale _entity) : base(_entity)
        {
        }
    }
}
