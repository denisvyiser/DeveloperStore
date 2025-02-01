using DevStore.Carts.Application.Queries;
using DevStore.Carts.Domain.Interfaces.Repositories;
using DevStore.Carts.Domain.Models.Entities;
using DevStore.Carts.Infrastructure.Repositories;
using DevStore.Core.Interfaces.Bus.MediatR;
using DevStore.Core.Mediatr.Handlers.Queries;

namespace DevStore.Products.Application.Handlers.Queries
{
    public class GetPaginatedCartProductsQueryHandler : GetPaginatedQueryHandler<GetPaginatedCartProductsQuery, CartProduct>
    {
        public GetPaginatedCartProductsQueryHandler(IMediatorHandler mediator, ICartProductsRepository repository) : base(mediator, repository)
        {
        }
    }
}
