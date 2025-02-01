using DevStore.Carts.Application.Commands;
using DevStore.Carts.Application.Events;
using DevStore.Carts.Domain.Interfaces.Repositories;
using DevStore.Carts.Domain.Models.Entities;
using DevStore.Core.Interfaces.Bus.MediatR;
using DevStore.Core.Mediatr.Handlers.Commands;

namespace DevStore.Carts.Application.Handlers.Commands
{
    public class RemoveCartProductCommandHandler : RemoveCommandHandler<RemoveCartProductCommand, CartProduct, CartProductRemovedEvent>
    {
        public RemoveCartProductCommandHandler(IMediatorHandler mediator, ICartProductsRepository repository) : base(mediator, repository)
        {

        }

    }
}