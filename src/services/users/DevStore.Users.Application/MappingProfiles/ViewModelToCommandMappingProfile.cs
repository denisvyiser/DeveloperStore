using AutoMapper;
using DevStore.Users.Application.Commands;
using DevStore.Users.Application.Views;
using DevStore.Users.Domain.Models.Enums;

namespace DevStore.Users.Application.MappingProfiles
{
    public class ViewModelToCommandMappingProfile
         : Profile
    {
        public ViewModelToCommandMappingProfile()
        {


            CreateMap<UserView, AddUserCommand>()
                .ConstructUsing(x => new AddUserCommand(x.Email, x.UserName, x.Password, x.Name, x.Address, x.Phone, x.Status, x.Role));

            CreateMap<UserView, UpdateUserCommand>()
                .ConstructUsing(x => new UpdateUserCommand(x.Id, x.Email, x.UserName, x.Password, x.Name, x.Address, x.Phone, x.Status, x.Role));/*(Status)Enum.Parse(typeof(Status), x.Status), (Role)Enum.Parse(typeof(Role), x.Role)));*/
                


        }
    }
}
