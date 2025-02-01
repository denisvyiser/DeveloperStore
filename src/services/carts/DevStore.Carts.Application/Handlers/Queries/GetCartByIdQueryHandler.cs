using DevStore.Carts.Application.Queries;
using DevStore.Carts.Domain.Interfaces.Repositories;
using DevStore.Carts.Domain.Models.Entities;
using DevStore.Core.Interfaces.Bus.MediatR;
using DevStore.Core.Mediatr.Handlers.Queries;


namespace DevStore.Users.Application.Handlers.Queries
{
    public class GetCartByIdQueryHandler : GetQueryHandlerAsync<GetCartByIdQuery, Cart>
    {
        public GetCartByIdQueryHandler(IMediatorHandler mediator, ICartsRepository repository) : base(mediator, repository)
        {
        }
    }
}
