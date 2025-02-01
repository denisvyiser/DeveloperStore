using AutoMapper;
using DevStore.Products.Application.MappingProfiles;

namespace DevStore.Users.Application.MappingProfiles
{
    public class MappingsConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(config =>
            {
                
                //config.AddProfile(new CommandToDomainMappingProfile());
            });
        }
    }
}