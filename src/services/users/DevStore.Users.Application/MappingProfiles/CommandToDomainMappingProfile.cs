using AutoMapper;
using DevStore.Users.Application.Commands;
using DevStore.Users.Domain.Models.Entities;

namespace DevStore.Users.Application.MappingProfiles
{
    public class CommandToDomainMappingProfile
         : Profile
    {
        public CommandToDomainMappingProfile()
        {
            CreateMap<AddUserCommand, User>()
                .ConstructUsing(c => new User(Guid.Empty,c.Email, c.UserName, c.Password, c.Phone, c.Status, c.Role))
                 .ForPath(dest => dest.Name, src => src.MapFrom(m => m.Name))
                .ForPath(dest => dest.Address, src => src.MapFrom(m => m.Address));

            CreateMap<UpdateUserCommand, User>()
    .ConstructUsing(c => new User(c.Id,c.Email, c.UserName, c.Password, c.Phone, c.Status, c.Role))
     .ForPath(dest => dest.Name, src => src.MapFrom(m => m.Name))
    .ForPath(dest => dest.Address, src => src.MapFrom(m => m.Address));
        }
    }
}
