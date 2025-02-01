using AutoMapper;
using DevStore.Core.Interfaces.Bus.MediatR;
using DevStore.Core.Mediatr.Handlers.Commands;
using DevStore.Sales.Application.Commands;
using DevStore.Sales.Application.Events;
using DevStore.Sales.Domain.Interfaces.Repositories;
using DevStore.Sales.Domain.Moldes.Entities;

namespace DevStore.Sales.Application.Handlers.Commands
{
    public class UpdateSaleCommandHandler : UpdateCommandHandler<UpdateSaleProductCommand, Sale, SaleUpdatedEvent>
    {
        public UpdateSaleCommandHandler(IMediatorHandler mediator, IMapper mapper, ISalesRepository repository) : base(mediator, mapper, repository)
        {

        }

        public override Task ApplyBusinessRulesAndPersist(Sale entity)
        {
            entity.ApplyDiscount();

            entity.SetTotalAmount();

            return base.ApplyBusinessRulesAndPersist(entity);
        }

    }
}