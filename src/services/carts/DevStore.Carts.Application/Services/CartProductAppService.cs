using AutoMapper;
using DevStore.Application.Core.Services;
using DevStore.Carts.Application.Commands;
using DevStore.Carts.Application.Interfaces;
using DevStore.Carts.Application.Queries;
using DevStore.Carts.Application.Views;
using DevStore.Carts.Domain.Models.Entities;
using DevStore.Core.Interfaces.Bus.MediatR;

namespace DevStore.Carts.Application.Services
{
    public class CartProductAppService : AppServiceBase<CartProductView, CartProduct, GetCartProductByIdQuery, GetPaginatedCartProductsQuery, AddCartProductCommand, UpdateCartCommand, RemoveCartCommand>, ICartProductAppService
    {
        public CartProductAppService(IMapper mapper, IMediatorHandler mediator) : base(mapper, mediator)
        {
        }
    }
}

