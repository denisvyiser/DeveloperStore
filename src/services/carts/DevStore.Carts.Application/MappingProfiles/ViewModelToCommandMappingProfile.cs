using AutoMapper;
using DevStore.Carts.Application.Commands;
using DevStore.Carts.Application.Views;

namespace DevStore.Users.Application.MappingProfiles
{
    public class ViewModelToCommandMappingProfile
         : Profile
    {
        public ViewModelToCommandMappingProfile()
        {
            CreateMap<CartView, AddCartCommand>()
                .ConstructUsing(x => new AddCartCommand(x.UserId, x.Status));

            CreateMap<CartView, UpdateCartCommand>()
                .ConstructUsing(x => new UpdateCartCommand(x.Id, x.UserId, x.Status));

            CreateMap<CartProductView, AddCartProductCommand>()
                .ConstructUsing(x => new AddCartProductCommand(x.ProductId, x.ProductTitle, x.ProductImage, x.Quantity, x.UnitPrice,x.CartId));

            CreateMap<CartProductView, UpdateCartProductCommand>()
                .ConstructUsing(x => new UpdateCartProductCommand(x.Id,x.ProductId, x.ProductTitle, x.ProductImage, x.Quantity, x.UnitPrice, x.CartId));
        }
    }
}
