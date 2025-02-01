using DevStore.Core.Interfaces.Bus.MediatR;
using DevStore.Core.Mediatr.Handlers.Commands;
using DevStore.Sales.Application.Commands;
using DevStore.Sales.Application.Events;
using DevStore.Sales.Domain.Interfaces.Repositories;
using DevStore.Sales.Domain.Moldes.Entities;

namespace DevStore.Sales.Application.Handlers.Commands
{
    public class RemoveSaleProductCommandHandler : RemoveCommandHandler<RemoveSaleProductCommand, SaleProduct, SaleProductRemovedEvent>
    {
        public RemoveSaleProductCommandHandler(IMediatorHandler mediator, ISaleProductsRepository repository) : base(mediator, repository)
        {

        }

    }
}