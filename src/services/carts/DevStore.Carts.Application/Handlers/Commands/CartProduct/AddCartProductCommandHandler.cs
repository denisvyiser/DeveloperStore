﻿using AutoMapper;
using DevStore.Carts.Application.Commands;
using DevStore.Carts.Application.Events;
using DevStore.Carts.Domain.Interfaces.Repositories;
using DevStore.Carts.Domain.Models.Entities;
using DevStore.Core.Interfaces.Bus.MediatR;
using DevStore.Core.Mediatr.Handlers.Commands;

namespace DevStore.Carts.Application.Handlers.Commands
{
    public class AddCartProductCommandHandler : AddCommandHandler<AddCartProductCommand, CartProduct, CartProductCreatedEvent>
    {
        public AddCartProductCommandHandler(IMediatorHandler mediator, IMapper mapper, ICartProductsRepository repository) : base(mediator, mapper, repository)
        {

        }

        //public override Expression<Func<DemoModel, bool>> generateQuery(DemoModel entity) => c => c.Description == entity.Description;

    }
}
