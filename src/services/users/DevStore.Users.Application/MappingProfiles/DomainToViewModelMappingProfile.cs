using AutoMapper;
using DevStore.Core.Models.Pagination;
using DevStore.Users.Application.Views;
using DevStore.Users.Domain.Models.Entities;

namespace DevStore.Users.Application.MappingProfiles
{
    public class DomainToViewModelMappingProfile
         : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<User, UserView>()
                .ForMember(dest => dest.Id, src => src.MapFrom(m => m.Id))
                .ForMember(dest => dest.Email, src => src.MapFrom(m => m.Email))
                .ForMember(dest => dest.UserName, src => src.MapFrom(m => m.UserName))
                .ForMember(dest => dest.Password, src => src.MapFrom(m => m.Password))
                .ForPath(dest => dest.Name, src => src.MapFrom(m => m.Name))
                .ForPath(dest => dest.Address, src => src.MapFrom(m => m.Address))
                .ForMember(dest => dest.Phone, src => src.MapFrom(m => m.Phone))
                .ForMember(dest => dest.Status, src => src.MapFrom(m => m.Status))
                .ForMember(dest => dest.Role, src => src.MapFrom(m => m.Role));

            CreateMap<PaginatedList<User>, PaginatedList<UserView>>()
                .ForMember(dest => dest.TotalItem, src => src.MapFrom(m => m.TotalItem))
                .ForMember(dest => dest.TotalPages, src => src.MapFrom(m => m.TotalPages))
                .ForMember(dest => dest.CurrentPage, src => src.MapFrom(m => m.CurrentPage))
                .ForPath(dest => dest.Data, src => src.MapFrom(m => m.Data));

        }
    }
}
