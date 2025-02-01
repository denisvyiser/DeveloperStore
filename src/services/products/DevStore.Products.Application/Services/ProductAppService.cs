using AutoMapper;
using DevStore.Application.Core.Services;
using DevStore.Core.Interfaces.Bus.MediatR;
using DevStore.Products.Application.Commands;
using DevStore.Products.Application.Interfaces;
using DevStore.Products.Application.Queries;
using DevStore.Products.Application.Views;
using DevStore.Products.Domain.Models.Entities;

namespace DevStore.Products.Application.Services
{
    public class ProductAppService : AppServiceBase<ProductView, Product, GetProductByIdQuery, GetProductPaginatedQuery, AddProductCommand, UpdateProductCommand, RemoveProductCommand>, IProductAppService
    {
        public ProductAppService(IMapper mapper, IMediatorHandler mediator) : base(mapper, mediator)
        {
        }
    }
}

