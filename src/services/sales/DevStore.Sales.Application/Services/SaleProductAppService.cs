using AutoMapper;
using DevStore.Application.Core.Services;
using DevStore.Core.Interfaces.Bus.MediatR;
using DevStore.Sales.Application.Commands;
using DevStore.Sales.Application.Interfaces;
using DevStore.Sales.Application.Queries;
using DevStore.Sales.Application.Views;
using DevStore.Sales.Domain.Moldes.Entities;

namespace DevStore.Sales.Application.Services
{
    public class SaleProductAppService : AppServiceBase<SaleProductView, SaleProduct, GetSaleProductByIdQuery, GetSaleProductPaginatedQuery, AddSaleProductCommand, UpdateSaleProductCommand, RemoveSaleProductCommand>, ISaleProductAppService
    {
        public SaleProductAppService(IMapper mapper, IMediatorHandler mediator) : base(mapper, mediator)
        {
        }
    }
}

