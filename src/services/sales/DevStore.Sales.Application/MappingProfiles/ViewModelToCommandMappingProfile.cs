using AutoMapper;
using DevStore.Sales.Application.Commands;
using DevStore.Sales.Application.Views;
using DevStore.Sales.Domain.Moldes.Enums;

namespace DevStore.Sales.Application.MappingProfiles
{
    public class ViewModelToCommandMappingProfile
         : Profile
    {
        public ViewModelToCommandMappingProfile()
        {
            CreateMap<SaleProductView, AddSaleProductCommand>()
                .ConstructUsing(x => new AddSaleProductCommand(x.ProductId, x.ProductTitle, x.ProductImage, x.Quantity, x.UnitPrice, x.Discount, x.SaleId, (Status)Enum.Parse(typeof(Status), x.Status)));

            CreateMap<SaleProductView, UpdateSaleProductCommand>()
                .ConstructUsing(x => new UpdateSaleProductCommand(x.Id, x.ProductId, x.ProductTitle, x.ProductImage, x.Quantity, x.UnitPrice, x.Discount, x.SaleId, (Status)Enum.Parse(typeof(Status), x.Status)));
        }
    }
}

