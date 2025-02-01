using DevStore.Core.Mediatr.Events;
using DevStore.Sales.Domain.Moldes.Entities;

namespace DevStore.Sales.Application.Events
{
    public class SaleProductRemovedEvent : Event<SaleProduct>
    {
        public SaleProductRemovedEvent(SaleProduct _entity) : base(_entity)
        {
        }
    }
}
