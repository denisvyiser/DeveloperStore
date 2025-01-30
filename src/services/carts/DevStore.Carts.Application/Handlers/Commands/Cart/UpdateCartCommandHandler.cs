using AutoMapper;
using DevStore.Carts.Application.Commands;
using DevStore.Carts.Application.Events;
using DevStore.Carts.Domain.Interfaces.Repositories;
using DevStore.Carts.Domain.Models.Entities;
using DevStore.Core.Interfaces.Bus.MediatR;
using DevStore.Core.Mediatr.Handlers.Commands;

namespace DevStore.Carts.Application.Handlers.Commands
{
    public class UpdateCartCommandHandler : UpdateCommandHandler<UpdateCartCommand, Cart, CartUpdatedEvent>
    {
        public UpdateCartCommandHandler(IMediatorHandler mediator, IMapper mapper, ICartsRepository repository) : base(mediator, mapper, repository)
        {

        }

    }
}