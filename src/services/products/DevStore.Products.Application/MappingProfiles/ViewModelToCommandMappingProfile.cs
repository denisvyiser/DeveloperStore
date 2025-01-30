using AutoMapper;
using DevStore.Products.Application.Commands;
using DevStore.Products.Application.Views;

namespace DevStore.Products.Application.MappingProfiles
{
    public class ViewModelToCommandMappingProfile
         : Profile
    {
        public ViewModelToCommandMappingProfile()
        {
            CreateMap<ProductView, AddProductCommand>()
                .ConstructUsing(x => new AddProductCommand(x.Title, x.Price, x.Description, x.Category, x.Image, x.Rating));

            CreateMap<ProductView, UpdateProductCommand>()
                .ConstructUsing(x => new UpdateProductCommand(x.Id, x.Title, x.Price, x.Description, x.Category, x.Image, x.Rating));
        }
    }
}
