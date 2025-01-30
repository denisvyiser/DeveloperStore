using DevStore.Products.Application.MappingProfiles;

namespace DevStore.Products.Api.Configurations
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            //services.AddAutoMapper(config => MappingsConfig.RegisterMappings());
            services.AddAutoMapper(config =>
            {
                config.AddProfile(new DomainToViewModelMappingProfile());
                config.AddProfile(new ViewModelToCommandMappingProfile());
                config.AddProfile(new CommandToDomainMappingProfile());
            });

            
            //MappingsConfig.RegisterMappings();
        }
    }
}