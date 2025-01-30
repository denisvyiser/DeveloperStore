using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DevStore.Db.Postgre.Extensions
{
    public static class MigrationManager
    {
        public static async Task MigrateDatabase<TContext>(WebApplication serviceScope) where TContext : DbContext
        {
            using (var scope = serviceScope.Services.GetService<IServiceScopeFactory>().CreateScope())
            {
                using (var appContext = scope.ServiceProvider.GetRequiredService<TContext>())
                {
                    try
                    {
                        appContext.Database.Migrate();
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Contains("already exists"))
                        { }

                        else//Log errors or do anything you think it's needed
                            throw;
                    }
                }
            }
            return;
        }

        //public static async Task MigrateDatabase<TContext>(WebApplication serviceScope) where TContext : DbContext
        //{
        //    using (var scope = serviceScope.Services.GetService<IServiceScopeFactory>().CreateScope())
        //    {
        //        using (var appContext = scope.ServiceProvider.GetRequiredService<TContext>())
        //        {
        //            try
        //            {
        //                await appContext.Database.EnsureCreatedAsync();
        //            }
        //            catch (Exception ex)
        //            {
        //                if (ex.Message.Contains("already exists"))
        //                { }

        //                else//Log errors or do anything you think it's needed
        //                    throw;
        //            }
        //        }
        //    }
        //    return;
        //}
    }
}
