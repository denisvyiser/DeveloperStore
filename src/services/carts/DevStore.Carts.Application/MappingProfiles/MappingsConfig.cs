using AutoMapper;
using DevStore.Users.Application.MappingProfiles;

namespace DevStore.Users.Application.MappingProfiles
{
    public class MappingsConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(config =>
            {
                config.AddProfile(new DomainToViewModelMappingProfile());
                config.AddProfile(new ViewModelToCommandMappingProfile());

                //config.AddProfile(new CommandToDomainMappingProfile());
            });
        }
    }
}