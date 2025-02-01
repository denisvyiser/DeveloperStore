using AutoMapper;
using DevStore.Application.Core.Services;
using DevStore.Carts.Application.Commands;
using DevStore.Carts.Application.Queries;
using DevStore.Carts.Application.Views;
using DevStore.Carts.Domain.Models.Entities;
using DevStore.Core.Interfaces.Bus.MediatR;
using DevStore.Users.Application.Interfaces;

namespace DevStore.Carts.Application.Services
{
    public class CartAppService : AppServiceBase<CartView, Cart, GetCartByIdQuery, GetPaginatedCartsQuery, AddCartCommand, UpdateCartCommand, RemoveCartCommand>, ICartAppService
    {
        public CartAppService(IMapper mapper, IMediatorHandler mediator) : base(mapper, mediator)
        {
        }
    }
}

