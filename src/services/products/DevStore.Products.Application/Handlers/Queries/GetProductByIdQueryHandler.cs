using DevStore.Core.Interfaces.Bus.MediatR;
using DevStore.Core.Mediatr.Handlers.Queries;
using DevStore.Products.Application.Queries;
using DevStore.Products.Domain.Interfaces.Repositories;
using DevStore.Products.Domain.Models.Entities;


namespace DevStore.Users.Application.Handlers.Queries
{
    public class GetProductByIdQueryHandler : GetQueryHandlerAsync<GetProductByIdQuery, Product>
    {
        public GetProductByIdQueryHandler(IMediatorHandler mediator, IProductsRepository repository) : base(mediator, repository)
        {
        }
    }
}
