using DevStore.Core.Interfaces.Bus.MediatR;
using DevStore.Core.Mediatr.Handlers.Queries;
using DevStore.Products.Application.Queries;
using DevStore.Products.Domain.Interfaces.Repositories;
using DevStore.Products.Domain.Models.Entities;

namespace DevStore.Products.Application.Handlers.Queries
{
    public class GetPaginatedProductsQueryHandler : GetPaginatedQueryHandler<GetProductPaginatedQuery, Product>
    {
        public GetPaginatedProductsQueryHandler(IMediatorHandler mediator, IProductsRepository repository) : base(mediator, repository)
        {
        }
    }
}
