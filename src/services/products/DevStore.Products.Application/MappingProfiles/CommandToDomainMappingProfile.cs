using AutoMapper;
using DevStore.Products.Application.Commands;
using DevStore.Products.Domain.Models.Entities;
using static System.Net.Mime.MediaTypeNames;

namespace DevStore.Products.Application.MappingProfiles
{
    public class CommandToDomainMappingProfile
         : Profile
    {
        public CommandToDomainMappingProfile()
        {
            CreateMap<AddProductCommand, Product>().ConstructUsing(c=> new Product(Guid.Empty, c.Title, c.Price, c.Description, c.Category, c.Image))
                .ForMember(dest => dest.Rating, src => src.MapFrom(m => m.Rating)); 

            CreateMap<UpdateProductCommand, Product>().ConstructUsing(c => new Product(c.Id,c.Title, c.Price, c.Description, c.Category, c.Image))
                .ForMember(dest => dest.Rating, src => src.MapFrom(m => m.Rating)); 
        }        
    }
}