using AutoMapper;
using DevStore.Carts.Application.Commands;
using DevStore.Carts.Domain.Models.Entities;

namespace DevStore.Users.Application.MappingProfiles
{
    public class CommandToDomainMappingProfile
         : Profile
    {
        public CommandToDomainMappingProfile()
        {
            CreateMap<AddCartCommand, Cart>()
                .ConstructUsing(c=> new Cart(Guid.Empty,c.UserId, c.Status));
            CreateMap<UpdateCartCommand, Cart>()
                .ConstructUsing(c => new Cart(c.Id,c.UserId, c.Status)); 

            CreateMap<AddCartProductCommand, CartProduct>()
                .ConstructUsing(c => new CartProduct(Guid.Empty,c.ProductId, c.ProductTitle, c.ProductImage, c.Quantity, c.UnitPrice, c.CartId));
            CreateMap<UpdateCartProductCommand, CartProduct>()
                .ConstructUsing(c => new CartProduct(c.Id,c.ProductId, c.ProductTitle, c.ProductImage, c.Quantity, c.UnitPrice, c.CartId)); ;
        }
    }
}
