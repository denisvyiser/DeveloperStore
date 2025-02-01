using AutoMapper;
using DevStore.Core.Interfaces.Bus.MediatR;
using DevStore.Core.Mediatr.Handlers.Commands;
using DevStore.Products.Application.Commands;
using DevStore.Products.Application.Events;
using DevStore.Products.Domain.Interfaces.Repositories;
using DevStore.Products.Domain.Models.Entities;

namespace DevStore.Products.Application.Handlers.Commands
{
    public class AddProductCommandHandler : AddCommandHandler<AddProductCommand, Product, ProductCreatedEvent>
    {
        public AddProductCommandHandler(IMediatorHandler mediator, IMapper mapper, IProductsRepository repository) : base(mediator, mapper, repository)
        {

        }

        //public override Expression<Func<DemoModel, bool>> generateQuery(DemoModel entity) => c => c.Description == entity.Description;

    }
}
