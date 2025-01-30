using AutoMapper;
using DevStore.Core.Interfaces.Bus.MediatR;
using DevStore.Core.Mediatr.Handlers.Commands;
using DevStore.Sales.Application.Commands;
using DevStore.Sales.Application.Events;
using DevStore.Sales.Domain.Interfaces.Repositories;
using DevStore.Sales.Domain.Moldes.Entities;

namespace DevStore.Sales.Application.Handlers.Commands
{
    public class UpdateSaleProductCommandHandler : UpdateCommandHandler<UpdateSaleProductCommand, SaleProduct, SaleProductUpdatedEvent>
    {
        public UpdateSaleProductCommandHandler(IMediatorHandler mediator, IMapper mapper, ISaleProductsRepository repository) : base(mediator, mapper, repository)
        {

        }

    }
}