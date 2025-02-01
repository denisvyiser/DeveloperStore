
using DevStore.Sales.Application.MappingProfiles;

namespace DevStore.Sales.Api.Configurations
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(config => MappingsConfig.RegisterMappings());
            //MappingsConfig.RegisterMappings();
        }
    }
}