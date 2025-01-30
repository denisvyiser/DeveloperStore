using DevStore.Carts.Application.Queries;
using DevStore.Carts.Domain.Interfaces.Repositories;
using DevStore.Carts.Domain.Models.Entities;
using DevStore.Core.Interfaces.Bus.MediatR;
using DevStore.Core.Mediatr.Handlers.Queries;

namespace DevStore.Products.Application.Handlers.Queries
{
    public class GetPaginatedCartsQueryHandler : GetPaginatedQueryHandler<GetPaginatedCartsQuery, Cart>
    {
        public GetPaginatedCartsQueryHandler(IMediatorHandler mediator, ICartsRepository repository) : base(mediator, repository)
        {
        }
    }
}
