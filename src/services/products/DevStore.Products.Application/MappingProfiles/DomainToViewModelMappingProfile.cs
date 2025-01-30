using AutoMapper;
using DevStore.Core.Models.Pagination;
using DevStore.Products.Application.Views;
using DevStore.Products.Domain.Models.Entities;

namespace DevStore.Products.Application.MappingProfiles
{
    public class DomainToViewModelMappingProfile
         : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Product, ProductView>()
                .ForMember(dest => dest.Id, src => src.MapFrom(m => m.Id))
                .ForMember(dest => dest.Title, src => src.MapFrom(m => m.Title))
                .ForMember(dest => dest.Price, src => src.MapFrom(m => m.Price))
                .ForMember(dest => dest.Description, src => src.MapFrom(m => m.Description))
                .ForMember(dest => dest.Category, src => src.MapFrom(m => m.Category))
                .ForPath(dest => dest.Image, src => src.MapFrom(m => m.Image))
                .ForPath(dest => dest.Rating, src => src.MapFrom(m => m.Rating));

            CreateMap<PaginatedList<Product>, PaginatedList<ProductView>>()
                .ForMember(dest => dest.TotalItem, src => src.MapFrom(m => m.TotalItem))
                .ForMember(dest => dest.TotalPages, src => src.MapFrom(m => m.TotalPages))
                .ForMember(dest => dest.CurrentPage, src => src.MapFrom(m => m.CurrentPage))
                .ForPath(dest => dest.Data, src => src.MapFrom(m => m.Data));

        }
    }
}

