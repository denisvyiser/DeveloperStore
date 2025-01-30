using DevStore.Core.Interfaces.Bus.MediatR;
using DevStore.Core.Mediatr.Handlers.Commands;
using DevStore.Sales.Application.Commands;
using DevStore.Sales.Application.Events;
using DevStore.Sales.Domain.Interfaces.Repositories;
using DevStore.Sales.Domain.Moldes.Entities;

namespace DevStore.Sales.Application.Handlers.Commands
{
    public class RemoveSaleCommandHandler : RemoveCommandHandler<RemoveSaleProductCommand, Sale, SaleRemovedEvent>
    {

        ISalesRepository _repository;
        public RemoveSaleCommandHandler(IMediatorHandler mediator, ISalesRepository repository) : base(mediator, repository)
        {
            _repository = repository;
        }

    }
}