using AutoMapper;
using DevStore.Sales.Application.Views;
using DevStore.Sales.Domain.Moldes.Entities;

namespace DevStore.Sales.Application.MappingProfiles
{
    public class DomainToViewModelMappingProfile
         : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Sale, SaleView>()
                .ForMember(dest => dest.Id, src => src.MapFrom(m => m.Id))
                .ForMember(dest => dest.Branch, src => src.MapFrom(m => m.Branch))
                .ForMember(dest => dest.TotalAmount, src => src.MapFrom(m => m.TotalAmount))
                .ForMember(dest => dest.Status, src => src.MapFrom(m => m.Status))
                .ForPath(dest => dest.Customer, src => src.MapFrom(m => m.Customer));

            CreateMap<SaleProduct, SaleProductView>()
                .ForMember(dest => dest.Id, src => src.MapFrom(m => m.Id))
                .ForMember(dest => dest.ProductId, src => src.MapFrom(m => m.ProductId))
                .ForMember(dest => dest.ProductTitle, src => src.MapFrom(m => m.ProductTitle))
                .ForMember(dest => dest.ProductImage, src => src.MapFrom(m => m.ProductImage))
                .ForMember(dest => dest.Quantity, src => src.MapFrom(m => m.Quantity))
                .ForMember(dest => dest.UnitPrice, src => src.MapFrom(m => m.UnitPrice))
                .ForMember(dest => dest.Discount, src => src.MapFrom(m => m.Discount))
                .ForMember(dest => dest.SaleId, src => src.MapFrom(m => m.SaleId))
                .ForMember(dest => dest.Status, src => src.MapFrom(m => m.Status));

        }
    }
}
