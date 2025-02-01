using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DevStore.Db.Postgre.Extensions
{
    public static class ContextExtension
    {
        public static IServiceCollection AddPostgresContext<TContext>(
             this IServiceCollection services,
             string connectionString) where TContext : DbContext

        {

            if (string.IsNullOrEmpty(connectionString))
                throw new Exception("Postgre connectionString is empty.");

            string assemblyName = typeof(TContext).Namespace.Replace(".Contexts", "").ToString();

            services.AddEntityFrameworkNpgsql().AddDbContext<TContext>(opt =>
            {
                opt.UseNpgsql(connectionString, npgsqlOptionsAction: (m) => m.MigrationsAssembly(assemblyName));
                opt.EnableSensitiveDataLogging();
                opt.EnableDetailedErrors();
            });

            return services;

        }

    }
}
