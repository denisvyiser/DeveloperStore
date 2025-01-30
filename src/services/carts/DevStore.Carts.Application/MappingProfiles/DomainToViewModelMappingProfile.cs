using AutoMapper;
using DevStore.Carts.Application.Views;
using DevStore.Carts.Domain.Models.Entities;
using DevStore.Core.Models.Pagination;

namespace DevStore.Users.Application.MappingProfiles
{
    public class DomainToViewModelMappingProfile
         : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Cart, CartView>()
                .ForMember(dest => dest.Id, src => src.MapFrom(m => m.Id))
                .ForMember(dest => dest.UserId, src => src.MapFrom(m => m.UserId))
                .ForMember(dest => dest.Status, src => src.MapFrom(m => m.Status));

            CreateMap<CartProduct, CartProductView>()
                .ForMember(dest => dest.Id, src => src.MapFrom(m => m.Id))
                .ForMember(dest => dest.ProductId, src => src.MapFrom(m => m.ProductId))
                .ForMember(dest => dest.ProductTitle, src => src.MapFrom(m => m.ProductTitle))
                .ForMember(dest => dest.ProductImage, src => src.MapFrom(m => m.ProductImage))
                .ForMember(dest => dest.Quantity, src => src.MapFrom(m => m.Quantity))
                .ForMember(dest => dest.UnitPrice, src => src.MapFrom(m => m.UnitPrice))
                .ForMember(dest => dest.CartId, src => src.MapFrom(m => m.CartId));

            CreateMap<PaginatedList<Cart>, PaginatedList<CartView>>()
               .ForMember(dest => dest.TotalItem, src => src.MapFrom(m => m.TotalItem))
               .ForMember(dest => dest.TotalPages, src => src.MapFrom(m => m.TotalPages))
               .ForMember(dest => dest.CurrentPage, src => src.MapFrom(m => m.CurrentPage))
               .ForPath(dest => dest.Data, src => src.MapFrom(m => m.Data));

            CreateMap<PaginatedList<CartProduct>, PaginatedList<CartProductView>>()
               .ForMember(dest => dest.TotalItem, src => src.MapFrom(m => m.TotalItem))
               .ForMember(dest => dest.TotalPages, src => src.MapFrom(m => m.TotalPages))
               .ForMember(dest => dest.CurrentPage, src => src.MapFrom(m => m.CurrentPage))
               .ForPath(dest => dest.Data, src => src.MapFrom(m => m.Data));
        }
    }
}
